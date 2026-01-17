using System.Diagnostics;

namespace TaskManager.Middleware;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    
    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var stopWatch = Stopwatch.StartNew();
        Console.WriteLine($"Request {context.Request.Method} {context.Request.Path}");
        await _next(context);
        stopWatch.Stop();
        Console.WriteLine($"Response {context.Response.StatusCode} {stopWatch.ElapsedMilliseconds} ms");
    }
}