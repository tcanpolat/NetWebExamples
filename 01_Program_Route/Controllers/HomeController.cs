using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
     
        // action
        public IActionResult Index() // Method => Geriye IActionResult döndüren bir method. IActionResult geriye bir sonuç sayfasý döndürür.
        {
            return View(); // method geriye IActionResult döndürmek zorunda olduðundan geriye bir view döndürüyoruz. Bu View => Views/Home/Index
        }

        // Home/About
        public IActionResult About()  // Sað týk Add View
        {
            return View();
        }

      
    }
}
