using _10_FluentValidation.ViewModels;
using FluentValidation;

namespace _10_FluentValidation.Validators
{
    public class homePageViewModelValidator : AbstractValidator<homePageViewModel>
    {
        public homePageViewModelValidator()
        {
            RuleFor(vm => vm.KisiNesnesi).NotNull().WithMessage("Kişi bilgileri boş bırakılamaz");
            RuleFor(vm => vm.AdresNesnesi).NotNull().WithMessage("Adres bilgileri boş bırakılamaz");

            RuleFor(vm => vm.KisiNesnesi.Ad)
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz")
                 .NotNull().WithMessage("Ad alanı boş bırakılamaz")
                .Length(1, 60).WithMessage("Ad alanı 1 ile 60 karakter arasında olmalıdır");
            
            RuleFor(vm => vm.KisiNesnesi.Soyad)
                .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz")
                .NotNull().WithMessage("Soyad alanı boş bırakılamaz")
                .Length(1, 60).WithMessage("Soyad alanı 1 ile 60 karakter arasında olmalıdır");
            
            RuleFor(vm => vm.KisiNesnesi.Yas)
               .GreaterThan(0).WithMessage("Yaş 0'dan büyük olmalıdır.")
               .LessThan(120).WithMessage("Yaş 120'den küçük olmalıdır.");
            
            RuleFor(vm => vm.AdresNesnesi.AdresTanim)
               .NotEmpty().WithMessage("Adres tanımı alanı boş bırakılamaz")
                .NotNull().WithMessage("Adres tanımı alanı boş bırakılamaz")
               .Length(1,100).WithMessage("Adres tanımı 1 ile 100 karakter arasında olmalıdır.");
           
            RuleFor(vm => vm.AdresNesnesi.Sehir)
              .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz")
              .NotNull().WithMessage("Şehir alanı alanı boş bırakılamaz")
              .Length(1, 50).WithMessage("Şehir adı 1 ile 50 karakter arasında olmalıdır.");
        }
    }
}
