using Harfiyat_Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Harfiyat_Ui.Areas.Admin.Controllers;

[Area("Admin")]
public class JobsController : Controller
{
    private readonly IBaseService _serviceManager;

    public JobsController(IBaseService serviceManager)
    {
        _serviceManager = serviceManager;
    }


    public IActionResult Index([FromQuery]int jobrequestid)
    {
        var jobRequest = _serviceManager.JobRequestService.GetByIdJobRequest(jobrequestid);
        ViewBag.JobRequest = jobRequest;
        var response = _serviceManager.JobService.GetAllWithJobRequest(jobrequestid);
        return View(response.Data);
    }
}
