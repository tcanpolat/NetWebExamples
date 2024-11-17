using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "�r�n 1","�r�n 2","�r�n 3" };

            // Veriyi View data ile view e yollama
            ViewData["Products"] = products;

            return View();
        }

        public IActionResult Details(int id)
        {
            var product = $"�r�n {id} Detaylar�";

            // Veriyi View data ile view e yollama
            ViewData["Product"] = product;

            return View();
        }

    }
}
