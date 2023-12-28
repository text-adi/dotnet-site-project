using Microsoft.AspNetCore.Mvc;

namespace dotnet_site_project.ViewComponents;

public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Ваш логіка для отримання даних для бічної панелі

        return View();
    }
}