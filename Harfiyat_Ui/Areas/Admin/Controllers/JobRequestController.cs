using Harfiyat_Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Harfiyat_Ui.Areas.Admin.Controllers;

[Area("Admin")]
public class JobRequestController : Controller
{
    private readonly IBaseService _serviceManager;

    public JobRequestController(IBaseService serviceManager)
    {
        _serviceManager = serviceManager;
    }


    public IActionResult Index()
    {
       var list = _serviceManager.JobRequestService.GetAllJobRequest();
       return View(list.Data);
    }
}
