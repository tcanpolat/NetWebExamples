using _12_Dependecy_Injection.Models;
using _12_Dependecy_Injection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependecy_Injection.Controllers
{
    public class HomeController : Controller
    {
       // IMyService t�r�ndeki servisi tutacak bir de�i�ken olu�turuyoruz.
        private readonly IMyService _myService;


        // Constructorda dependecy injection ile servisi al�yoruz.
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }
        public IActionResult Index()
        {
            // Servisten d�nen studentlar� getiriyoruz ve bir listeye at�yoruz.
            List<Student> students = _myService.GetStudents();
            
            return View(students);
        }

       
    }
}
