using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _08_Render_Section_Nested.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
