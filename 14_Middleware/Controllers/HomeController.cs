using _14_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middleware.Controllers
{
    public class HomeController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }
    }
}
