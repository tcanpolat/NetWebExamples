using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
     
        // action
        public IActionResult Index() // Method => Geriye IActionResult d�nd�ren bir method. IActionResult geriye bir sonu� sayfas� d�nd�r�r.
        {
            return View(); // method geriye IActionResult d�nd�rmek zorunda oldu�undan geriye bir view d�nd�r�yoruz. Bu View => Views/Home/Index
        }

        // Home/About
        public IActionResult About()  // Sa� t�k Add View
        {
            return View();
        }

      
    }
}
