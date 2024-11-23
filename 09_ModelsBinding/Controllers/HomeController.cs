using _09_ModelsBinding.Models;
using _09_ModelsBinding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_ModelsBinding.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult HomePage()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 33
            };
            return View(kisi);
        }

        public IActionResult HomePage2()
        {
            // Buradaki sorun 2 modeli tek bir model gibi view e yollayabilmek.
            // Bu durum i�in view model kavram� kullan�l�r.
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 33
            };

            Adres adres = new Adres()
            {
                AdresTanim = "Kad�k�y/Cafera�a mah.",
                Sehir = "�stanbul"
            };

            homePageViewModel viewModel = new homePageViewModel();
            viewModel.AdresNesnesi = adres;
            viewModel.KisiNesnesi = kisi;

            return View(viewModel);

        }




    }
}
