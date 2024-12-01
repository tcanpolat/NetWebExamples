using _15_Filter_Operation.Filters;
using _15_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operation.Controllers
{
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class HomeController : Controller
    {

        [ServiceFilter(typeof (ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }


        [ServiceFilter(typeof(AuthorizationFilter))] // Bu filter login olmadýysa sayfa yönlendirmesi yapar.
        public IActionResult Privacy() // Bu sayfaya login olmayanlar gidemesin.
        {
            return View();
        }
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpecialAction()
        {
            throw new Exception("Bu bir test hatasýdýr.");
        }

        


    }
}
