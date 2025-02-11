using Harfiyat_Common.ResponseObjects;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Services;

public interface IJobRequestService
{
    IResponse<IEnumerable<JobRequest>> GetAllJobRequest(bool trackChanges=false);

    IResponse<JobRequest?> GetByIdJobRequest(int id, bool trackChanges=false);

    IResponse AddJobRequest(JobRequest entity);

    IResponse UpdateJobRequest(JobRequest entity);

    IResponse DeleteJobRequest(JobRequest entity);
    IResponse<IEnumerable<JobRequest>> GetAllJobRequestWithJobs(bool trackChanges=false);
}
