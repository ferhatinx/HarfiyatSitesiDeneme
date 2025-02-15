using Harfiyat_Business.Interfaces;
using Harfiyat_Entities.Entities;
using Harfiyat_Ui.Areas.Admin.Extensions;
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
    public IActionResult ActiveJobsRequest()
    {
        var response = _serviceManager.JobRequestService.GetAllWithConditionJobRequest(x=>x.IsApproved == true);
        return this.ResponseView(response);
    }
    public IActionResult WaitingWorks()
    {
        var response = _serviceManager.JobRequestService.GetAllWithConditionJobRequest(x=>x.IsApproved == false);
        return this.ResponseView(response);
    }
    public IActionResult Accept(int id)
    {
        var response = _serviceManager.JobRequestService.AcceptJobRequest(id);
        return this.ResponseView(response,"WaitingWorks","JobRequest");
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(JobRequest jobRequest)
    {
        var response = _serviceManager.JobRequestService.AddJobRequest(jobRequest);
        return this.ResponseView(response,"Index","JobRequest");
    }
    public IActionResult Delete(int id)
    {
        var response =_serviceManager.JobRequestService.DeleteJobRequest(id);
        return this.ResponseView(response,"WaitingWorks","Jobs");
    }
}
