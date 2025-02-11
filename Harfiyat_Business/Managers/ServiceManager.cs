using Harfiyat_Business.Interfaces;
using Harfiyat_Business.Services;

namespace Harfiyat_Business.Managers;

public class ServiceManager : IBaseService
{
    private readonly IJobRequestService _jobRequestService;
    private readonly IJobService _jobService;

    public ServiceManager(IJobRequestService jobRequestService, IJobService jobService)
    {
        _jobRequestService = jobRequestService;
        _jobService = jobService;

    }


    public IJobRequestService JobRequestService => _jobRequestService;

    public IJobService JobService => _jobService;
}
