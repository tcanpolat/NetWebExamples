using _19_DapperExample.Data;
using _19_DapperExample.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace _19_DapperExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly DapperContext _context;

        public ProductController(DapperContext context)
        {
            _context = context;
        }
        
        // Tüm ürünleri ve kategorileri listeleyen ana sayfa methodu
        public async Task<IActionResult> Index()
        {
            // ürünleri ve kategorileri birleştirerek seçen sql sorgusu
            var query = "select * from Products inner join Categories on Products.CategoryId = Categories.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                // Dapper ile çoklu tablo sorgulama
                var products = await connection.QueryAsync<Product, Category, Product>(
                    query,
                    (product,category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    splitOn: "CategoryId" // Kategorileri ayırmak için kullanılan sütun
                    );
                
                return View(products.ToList());

            }


        }

        // Ürün oluşturacağımız sayfa
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var query = "INSERT INTO Products (Name,Price,CategoryId) VALUES (@Name,@Price,@CategoryId)";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, product);
                // işlem tamamlandığında anasayfaya yönlendir.
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Ürün düzenleme sayfasını döndüren method

        public async Task<IActionResult> Edit(int id)
        {
            // Gelen id li ürünün sorgusu
            var query = "SELECT * FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });

                if(product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            // Gelen ürüne göre güncelleme sorgusu
            var query = "UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE ProductId = @ProductId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,product);

                return RedirectToAction("Index");
            }

        }

        // Ürünü silme sayfasını döndüren method
        public async Task<IActionResult> Delete(int id)
        {
            // Gelen id li ürünün sorgusu
            var query = "SELECT * FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });

                if (product == null)
                {
                    return NotFound("Product Not Found");
                }

                return View(product);
            }

        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Gelen id li ürünü silme sorgusu
            var query = "DELETE FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });

                if(result > 0)
                {
                    ViewBag.Message = "Product Delete Successfully";
                }
                else
                {
                    ViewBag.Message = "Product Delete Failed";
                }
                return View("DeleteResult"); // Silme sonucunu göstereceğim sayfa
            }

        }

        // Ürünün detay sayfasını döndüren method
        public async Task<IActionResult> Details(int id)
        {
            // Gelen id li ürünün sorgusu
            var query = "SELECT * FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });

                if (product == null)
                {
                    return NotFound("Product Not Found");
                }

                return View(product);
            }

        }


    }
}
