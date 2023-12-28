using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_site_project.Models;
using Microsoft.AspNetCore.Localization;

namespace dotnet_site_project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Open Main page");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(LoginModel person)
    {
        if (ModelState.IsValid)
            return Content($"{person.Id} - {person.Name} - {person.Name2} - {person.Name3} - {person.Name4} - {person.Name5} - {person.Name6} - {person.Name7} - {person.Name8} - {person.Name9}");
        else
        {
            return View(person);            
        }
    }
    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return LocalRedirect(returnUrl);
    }
}