using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ViewToController.Controllers
{
    public class HomeController : Controller
    {

        // get
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string ad, string kisiler, bool onay = false)
        {
            var k1 = Request.Form["kisiler"];
            var a1 = Request.Form["ad"];
            var o1 = Request.Form["onay"];

            ViewBag.name = a1;
            return View();
        }

    }
}
