using _13_State_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            // Session(Oturum) - Cookie (�erezler)
            // Session stateler uyguluman�n �al��t��� s�re boyunca (oturum boyunca) verileri saklamam�z� sa�layan yap�lard�r. Oturum sona erdi�inde (Uygulama kapat�ld���nda yada sonland�r�ld���nda) sessiondaki veriler otomatik olarak silinir. Sessionlarda �zel bilgilerin saklanmas� �nerilmez. Sessionlar sunucu taraf�nda tutulur.

            HttpContext.Session.SetString("UserName","Tahsin Canpolat");

            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            // Cookie
            // Cookieler taray�c� taraf�nda (kullan�c� taraf�nda) tutulur. Key-value ili�kisinde tutulur. Bir expire date i (ya�am s�resi) vard�r. Bu ya�am s�resi doldu�unda cookie silinir.
            // 
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true
            };

            Response.Cookies.Append("UserName", "Tahsin Canpolat", cookieOptions);

            var cookieUserName = Request.Cookies["UserName"];

            ViewBag.CookieUserName = cookieUserName;


            return View();
        }

       
    }
}
