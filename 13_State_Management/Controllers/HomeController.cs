using _13_State_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            // Session(Oturum) - Cookie (Çerezler)
            // Session stateler uygulumanýn çalýþtýðý süre boyunca (oturum boyunca) verileri saklamamýzý saðlayan yapýlardýr. Oturum sona erdiðinde (Uygulama kapatýldýðýnda yada sonlandýrýldýðýnda) sessiondaki veriler otomatik olarak silinir. Sessionlarda özel bilgilerin saklanmasý önerilmez. Sessionlar sunucu tarafýnda tutulur.

            HttpContext.Session.SetString("UserName","Tahsin Canpolat");

            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            // Cookie
            // Cookieler tarayýcý tarafýnda (kullanýcý tarafýnda) tutulur. Key-value iliþkisinde tutulur. Bir expire date i (yaþam süresi) vardýr. Bu yaþam süresi dolduðunda cookie silinir.
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
