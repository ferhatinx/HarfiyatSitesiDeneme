using Microsoft.AspNetCore.Mvc;

namespace Harfiyat_Ui.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
