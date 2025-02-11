using System.Linq.Expressions;
using Harfiyat_Entities.Entities;

namespace Harfiyat_DataAccess.Contracts;

public interface IJobRequestReepository : IBaseRepository<JobRequest>
{
    IEnumerable<JobRequest> GetAllWithConditionJobRequest(Expression<Func<JobRequest,bool>> expression,bool trackChanges = false);
    IEnumerable<JobRequest> GetAllJobRequest(bool trackChanges=false);

    IEnumerable<JobRequest>? GetAllJobRequestWithJobs(bool trackChanges=false);
    JobRequest? GetByIdJobRequest(int id, bool trackChanges=false);

    void AddJobRequest(JobRequest entity);

    void UpdateJobRequest(JobRequest entity);

    void DeleteJobRequest(JobRequest entity);

}
