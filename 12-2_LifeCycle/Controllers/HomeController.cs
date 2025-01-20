using _12_2_LifeCycle.Helpers;
using _12_2_LifeCycle.Services;
using Microsoft.AspNetCore.Mvc;

namespace _12_2_LifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransientRandomNumberService _transientService;// ilk çaðrýlýþ
        private readonly TransientRandomNumberService _transientService1;//ayný istek üzerinden 2. çaðrýlýþ
        private readonly ScopedHelperService _scopedHelperService;// ilk çaðrýlýþ
        private readonly ScopedHelperService _scopedHelperService1;//ayný istek üzerinden 2. caðrýlýþ
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
            // Ayný HTTP isteðinde Scoped ve Transient karþýlaþtýrmasý
            var transientValue1 = _transientService.GetRandomNumber();// ayný istek üzerinden farklý deðerler verecektir her istekde yeni nesne oluþturacaktýr
            var transientValue2 = _transientService1.GetRandomNumber();

            var scopedValue1 = _scopedHelperService.GetScopedNumber();//ayný istek üzerinden tek bir deðer alacaktýr HTTP isteði yenilenmediði sürece ayný istekden devam eder           
            var scopedValue2 = _scopedHelperService1.GetScopedNumber();

            var singletonValue1 = _singletonService.GetRandomNumber();//HTTP isteði yenilense de ayný isteði verecektir tek nesne üzerinden iþlem yapar deðiþmez
            var singletonValue2 = _singletonService.GetRandomNumber();

            // Deðerleri View'e gönder
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
