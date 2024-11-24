using _10_FluentValidation.Models;
using _10_FluentValidation.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<homePageViewModel> _validator;

        public HomeController(IValidator<homePageViewModel> validator)
        {
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(homePageViewModel model)
        {
            // modeli valide et
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }

                return View("Index",model); // eðer model validationda bir hata varsa tekrar forma döndür.
            }
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }


    }
}
