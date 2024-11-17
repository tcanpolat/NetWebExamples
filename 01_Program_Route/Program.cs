var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Bu uygulama otomatik router sistemi kullans�n.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute( // kendi �zel rotam�z� yazd�k => /hakkimizda route u HomeControllerdaki About action result�n� �al��t�r�r.
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
