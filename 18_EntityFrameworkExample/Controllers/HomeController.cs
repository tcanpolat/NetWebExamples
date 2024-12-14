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
            // Students tablosundaki t�m ��rencileri al
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        // ��renci detaylar�n� g�sterme
        public IActionResult Details(int id) 
        {
            // ID'ye g�re ��renciyi bul
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
                // model ge�erliyse yeni ��renci ekle
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // ��renciyi d�zenleme
        public IActionResult Edit(int id)
        {
            // ID'ye g�re ��renciyi bul
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
                    // ��renci bilgilerini g�ncelle
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

        // ��renci silme formu
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
                // tablodan silme i�lemi
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }


        // Sorgu s�z dizimi ile sql den ya�� 18 den b�y�k olan ��rencileri listele
        public IActionResult QuerySyntax()
        {
            var students = (from s in _context.Students
                            where s.Age > 18
                            select s
                            ).ToList();

            // Sonu�lar� index view'ine g�nderelim
            return View(students);

        }

        // Method s�z dizimi ile sql den ya�� 18 den k���k olan ��rencileri listele
        public IActionResult MethodSyntax()
        {
            var students = _context.Students.Where(s => s.Age < 18).ToList();

            // Sonu�lar� index view'ine g�nderelim
            return View(students);

        }

        // ��renciler ve kurslar aras�ndaki ili�kiyi kullanarak join i�lemi yapma
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
