using _12_Dependecy_Injection.Services.Abstract;
using _12_Dependecy_Injection.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* 
     IMyService i ve MyService i container a ekliyoruz.
    .NET CORE da Dependency Injection da servislerin �mr�n� (lifecycle) belirtmek i�in �� ana y�ntem kullan�l�r. AddTransient, AddScoped, AddSingelton
    1. AddTransient
    Her istek i�in yeni bir nesne olu�turulur. Yani bir servis her kulland�ld���nda yeni bir instance olu�turulur.
    Bu durum maliyetlidir. Performans a��s�ndan s�k�nt�lar yaratabilir
    2. AddScoped
    Her istek i�in yeni bir nesne olu�turulur. Ayn� istek i�inde ayn� servis nesnesi kullan�l�r. Ancak farkl� isteklerde farkl� nesneler olu�turulur.
    3. AddSingelton
    Uygulama ba�lad���nda bir kez olu�turlan ve uygulama ya�am d�ng�s� boyunca ayn� kalan tek bir nesne olu�uturulur ve kullan�l�r. Performans a��s�ndan en verimlisidir. ��nk� nesne bir kez olu�turulur.

 
 */
builder.Services.AddTransient<IMyService,MyService>(); // Servisi uygulama container�na ekledik.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
