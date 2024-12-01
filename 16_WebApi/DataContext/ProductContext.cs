using _16_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _16_WebApi.DataContext
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
