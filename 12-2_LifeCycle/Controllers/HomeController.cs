using _12_2_LifeCycle.Helpers;
using _12_2_LifeCycle.Services;
using Microsoft.AspNetCore.Mvc;

namespace _12_2_LifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransientRandomNumberService _transientService;// ilk �a�r�l��
        private readonly TransientRandomNumberService _transientService1;//ayn� istek �zerinden 2. �a�r�l��
        private readonly ScopedHelperService _scopedHelperService;// ilk �a�r�l��
        private readonly ScopedHelperService _scopedHelperService1;//ayn� istek �zerinden 2. ca�r�l��
        private readonly SingletonRandomNumberService _singletonService;

        public HomeController(
            TransientRandomNumberService transientService, TransientRandomNumberService transientService1,
            ScopedHelperService scopedHelperService, ScopedHelperService scopedHelperService1,
            SingletonRandomNumberService singletonService)
        {
            _transientService = transientService;
            _transientService1 = transientService1;
            _scopedHelperService = scopedHelperService;
            _scopedHelperService1 = scopedHelperService1;
            _singletonService = singletonService;
        }

        public IActionResult Index()
        {
            // Ayn� HTTP iste�inde Scoped ve Transient kar��la�t�rmas�
            var transientValue1 = _transientService.GetRandomNumber();// ayn� istek �zerinden farkl� de�erler verecektir her istekde yeni nesne olu�turacakt�r
            var transientValue2 = _transientService1.GetRandomNumber();

            var scopedValue1 = _scopedHelperService.GetScopedNumber();//ayn� istek �zerinden tek bir de�er alacakt�r HTTP iste�i yenilenmedi�i s�rece ayn� istekden devam eder           
            var scopedValue2 = _scopedHelperService1.GetScopedNumber();

            var singletonValue1 = _singletonService.GetRandomNumber();//HTTP iste�i yenilense de ayn� iste�i verecektir tek nesne �zerinden i�lem yapar de�i�mez
            var singletonValue2 = _singletonService.GetRandomNumber();

            // De�erleri View'e g�nder
            ViewBag.Transient1 = transientValue1;
            ViewBag.Transient2 = transientValue2;

            ViewBag.Scoped1 = scopedValue1;
            ViewBag.Scoped2 = scopedValue2;

            ViewBag.Singleton1 = singletonValue1;
            ViewBag.Singleton2 = singletonValue2;

            return View();
        }
    }
}
