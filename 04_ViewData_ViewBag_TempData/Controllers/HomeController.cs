using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        // Controllerdan View'e veri taþýmak için kullanýlan yöntemler
        // - ViewBag: Dinamik bir özellik olup, controllerdan view e veri taþýr.
        // - ViewData: Sözlük (Dictonary) benzeri bir yapýdýr. controllerdan view e veri taþýr.
        // - TempData: Geçici veri taþýmak için kullanýlýr ve iki sonuç (action,view) arasýnda veri taþýr.
        public IActionResult Index()
        {
            // viewbag dinamik özellikler aracýlýðýyla veri taþýr ve 1 sonuç(action) boyunca geçerlidir.
            ViewBag.ad = "Tahsin";

            ArrayList liste = new ArrayList();
            liste.Add("A");
            liste.Add(10);
            ViewBag.liste = liste;

            ViewBag.sonuc = true;

            // viewdata key-value (anahtar-deðer) iliþkisiyle veriyi tutar ve 1 sonuç(action) boyunca geçerlidir.
            ViewData["soyad"] = "Canpolat";

            // tempdata key-value (anahtar-deðer) iliþkisiyle veriyi tutar ve 2 sonuç(action) boyunca geçerlidir.
            TempData["cinsiyet"] = "Erkek";

            return View();
        }


        public IActionResult About()
        {
            
            ViewBag.text = ViewBag.ad; // ViewBag.ad Index methodunda tanýmlandýðýnda 2 sonuç arasý taþýnamaz.

            TempData["c"] = TempData["cinsiyet"];

            return View();
        }
       
    }
}
