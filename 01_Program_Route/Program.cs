var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Bu uygulama otomatik router sistemi kullansýn.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute( // kendi özel rotamýzý yazdýk => /hakkimizda route u HomeControllerdaki About action resultýný çalýþtýrýr.
    name: "about",
    pattern: "hakkimizda",
    defaults: new {controller = "Home" , action = "About"}
);

app.MapControllerRoute(
    name: "blogDetails",
    pattern: "blog/details/{id}",
    defaults: new { controller = "Blog", action = "Details" },
    constraints: new { id = @"\d+" }
);


app.Run();
