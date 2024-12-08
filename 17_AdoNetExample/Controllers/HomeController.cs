using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _17_AdoNetExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;

        public HomeController(IDbService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData() {
            string query = "insert into Students (FirstName,LastName,Age) values ('Tahsin','Canpolat',33)";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddDataSecure([FromForm] Student model)
        {
            // Sql sorgusunu parametrik bir þekilde gerçekleþtirir. Sql injection saldýrýlarýna karþý güvenli hale getirir.
            string query = "insert into Students (FirstName,LastName,Age) values (@FirstName,@LastName,@Age)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@Age",model.Age),
            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetData() {
            string query = "SELECT FirstName,LastName,Age FROM Students";
            var data = _dbService.ExecuteReader(query);
            return View(data);
        
        }

        [HttpGet]
        public IActionResult GetCount()
        {
            string query = "SELECT COUNT(*) FROM Students";
            var count = _dbService.ExecuteScalar(query);
            return View(count);

        }


    }
}
