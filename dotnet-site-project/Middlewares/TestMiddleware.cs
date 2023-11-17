using dotnet_site_project.Services;

namespace dotnet_site_project.Middlewares;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync("Test");
        await _next(context);
        
    }
}