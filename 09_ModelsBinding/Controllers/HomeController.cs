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
            // Bu durum için view model kavramý kullanýlýr.
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 33
            };

            Adres adres = new Adres()
            {
                AdresTanim = "Kadýköy/Caferaða mah.",
                Sehir = "Ýstanbul"
            };

            homePageViewModel viewModel = new homePageViewModel();
            viewModel.AdresNesnesi = adres;
            viewModel.KisiNesnesi = kisi;

            return View(viewModel);

        }




    }
}
