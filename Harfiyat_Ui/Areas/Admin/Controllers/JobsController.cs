using Harfiyat_Business.Interfaces;
using Harfiyat_Entities.Entities;
using Harfiyat_Ui.Areas.Admin.Extensions;
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
        ViewBag.JobRequest = jobRequest.Data;
        var response = _serviceManager.JobService.GetAllWithJobRequest(jobrequestid);
        return View(response.Data);
    }
    public IActionResult Create([FromQuery]int jobRequestId)
    {   
        ViewBag.rqId = jobRequestId;
        return View();
    }
    [HttpPost]
    public IActionResult Create(Job job)
    {
        var responseJobAdd = _serviceManager.JobService.AddJob(job);
        return this.ResponseView(responseJobAdd,"Index","Jobs",routeValue: new { jobrequestid = job.JobRequestId});
    }
    public IActionResult Update([FromQuery]int jobid)
    {
        var response = _serviceManager.JobService.GetByIdJob(jobid);
        return this.ResponseView(response);
    }
    [HttpPost]
    public IActionResult Update(Job job)
    {
        var response = _serviceManager.JobService.UpdateJob(job);
        return this.ResponseRedirectToView(response,"Index","Jobs", new {jobrequestid = job.JobRequestId});
    }
    public IActionResult Completed([FromRoute]int id,[FromQuery(Name ="jobrequestid")]int jobRequestId)
    {
        
        var response = _serviceManager.JobService.CompletedJob(id);
        return this.ResponseView(response,"Index","Jobs",new { jobrequestid = jobRequestId});
    }
     public IActionResult Delete([FromRoute]int id,[FromQuery(Name ="jobrequestid")]int jobRequestId)
    {
        
        var response = _serviceManager.JobService.DeleteJob(id);
        return this.ResponseView(response,"Index","Jobs",new { jobrequestid = jobRequestId});
    }
}
