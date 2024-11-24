using _12_Dependecy_Injection.Models;
using _12_Dependecy_Injection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependecy_Injection.Controllers
{
    public class HomeController : Controller
    {
       // IMyService türündeki servisi tutacak bir deðiþken oluþturuyoruz.
        private readonly IMyService _myService;


        // Constructorda dependecy injection ile servisi alýyoruz.
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }
        public IActionResult Index()
        {
            // Servisten dönen studentlarý getiriyoruz ve bir listeye atýyoruz.
            List<Student> students = _myService.GetStudents();
            
            return View(students);
        }

       
    }
}
