using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        // Controllerdan View'e veri ta��mak i�in kullan�lan y�ntemler
        // - ViewBag: Dinamik bir �zellik olup, controllerdan view e veri ta��r.
        // - ViewData: S�zl�k (Dictonary) benzeri bir yap�d�r. controllerdan view e veri ta��r.
        // - TempData: Ge�ici veri ta��mak i�in kullan�l�r ve iki sonu� (action,view) aras�nda veri ta��r.
        public IActionResult Index()
        {
            // viewbag dinamik �zellikler arac�l���yla veri ta��r ve 1 sonu�(action) boyunca ge�erlidir.
            ViewBag.ad = "Tahsin";

            ArrayList liste = new ArrayList();
            liste.Add("A");
            liste.Add(10);
            ViewBag.liste = liste;

            ViewBag.sonuc = true;

            // viewdata key-value (anahtar-de�er) ili�kisiyle veriyi tutar ve 1 sonu�(action) boyunca ge�erlidir.
            ViewData["soyad"] = "Canpolat";

            // tempdata key-value (anahtar-de�er) ili�kisiyle veriyi tutar ve 2 sonu�(action) boyunca ge�erlidir.
            TempData["cinsiyet"] = "Erkek";

            return View();
        }


        public IActionResult About()
        {
            
            ViewBag.text = ViewBag.ad; // ViewBag.ad Index methodunda tan�mland���nda 2 sonu� aras� ta��namaz.

            TempData["c"] = TempData["cinsiyet"];

            return View();
        }
       
    }
}
