using _05_Html_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _05_Html_Helpers.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            User user = new User();
            user.CountryList = GetCountries();
            user.Name = "Tahsin";

            return View(user); // modeli view e yollama
        }

        public IEnumerable<SelectListItem> GetCountries()
        {
            return new SelectListItem[]
            {
                new SelectListItem(){ Value = "US" , Text = "USA"},
                new SelectListItem(){ Value = "TR" , Text = "Türkiye"},
                new SelectListItem(){ Value = "JP" , Text = "Japonya"},
            };
        }

    }
}
