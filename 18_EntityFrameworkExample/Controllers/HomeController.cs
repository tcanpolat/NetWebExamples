using _18_EntityFrameworkExample.Data;
using _18_EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _18_EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Students tablosundaki tüm öðrencileri al
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        // Öðrenci detaylarýný gösterme
        public IActionResult Details(int id) 
        {
            // ID'ye göre öðrenciyi bul
            var student = _context.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }

            return View(student);
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Age,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                // model geçerliyse yeni öðrenci ekle
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Öðrenciyi düzenleme
        public IActionResult Edit(int id)
        {
            // ID'ye göre öðrenciyi bul
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Id,Name,Age,Department")] Student student)
        {
            if(id != student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // öðrenci bilgilerini güncelle
                    _context.Update(student);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

            }

            return View(student);
        }

        // Öðrenci silme formu
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                // tablodan silme iþlemi
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }


        // Sorgu söz dizimi ile sql den yaþý 18 den büyük olan öðrencileri listele
        public IActionResult QuerySyntax()
        {
            var students = (from s in _context.Students
                            where s.Age > 18
                            select s
                            ).ToList();

            // Sonuçlarý index view'ine gönderelim
            return View(students);

        }

        // Method söz dizimi ile sql den yaþý 18 den küçük olan öðrencileri listele
        public IActionResult MethodSyntax()
        {
            var students = _context.Students.Where(s => s.Age < 18).ToList();

            // Sonuçlarý index view'ine gönderelim
            return View(students);

        }

        // Öðrenciler ve kurslar arasýndaki iliþkiyi kullanarak join iþlemi yapma
        public IActionResult Join()
        {
            var studentCourses = (from student in _context.Students
                                  join course in _context.Courses on student.Id equals course.StudentId
                                  select new
                                  {
                                      StudentName = student.Name,
                                      CourseTitle = course.Title
                                  }).ToList();

            return View(studentCourses);
        }

    }
}
