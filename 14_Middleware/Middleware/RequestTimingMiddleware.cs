using System.Diagnostics;

namespace _14_Middleware.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew(); // Zaman ölçümü başlat.

            await _next(context); // Bir sonraki middleware e geç.

            watch.Stop(); // Zaman ölçümünü durdur.

            var elapsed = watch.ElapsedMilliseconds; // Geçen süreyi milisaniye cinsinden al.

            Debug.WriteLine($"İstek Yolu: {context.Request.Path} - İşleme Süresi: {elapsed}");
        }
    }
}
