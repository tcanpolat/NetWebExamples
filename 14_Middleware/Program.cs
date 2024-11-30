using _14_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseMiddleware<RequestTimingMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*
 * Middleware nedir ?
 * Middleware, .NET Core uygulamalarýnda gelen istekleri (request) iþlemek ve yanýtlarý (response) oluþturmak için kullanýlan bir yazýlým bileþenidir. Middleware'ler genellikle HTTP isteklerini ve yanýtlarýný iþlemenin yaný sýra, uygulumanýn çeþitli iþlevlerinide yerine getirir. Ýsteði iþleyip bir sonraki middleware'e geçebilir ya da yanýtý oluþturulabilir.

 
 */

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
