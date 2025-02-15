using System.Linq.Expressions;
using Harfiyat_DataAccess.Context;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harfiyat_DataAccess.Concrete;

public class JobRequestRepository : BaseRepository<JobRequest>, IJobRequestReepository
{
    private readonly ConsturactionContext _context;
    public JobRequestRepository(ConsturactionContext context) : base(context)
    {
        _context = context;
    }

    public void AddJobRequest(JobRequest entity) => Add(entity);


    public void DeleteJobRequest(JobRequest entity) => Delete(entity);


    public IEnumerable<JobRequest> GetAllJobRequest(bool trackChanges = false) => GetAll(trackChanges);

    public IEnumerable<JobRequest>? GetAllJobRequestWithJobs(bool trackChanges = false)
    {
        var JobRequestWithJobs = _context.JobRequests?.Include(x=>x.Jobs).ToList();
        return JobRequestWithJobs;
    }

    public IEnumerable<JobRequest> GetAllWithConditionJobRequest(Expression<Func<JobRequest, bool>> expression, bool trackChanges = false) 
    => GetAllWithCondition(expression,trackChanges);
   

    public JobRequest? GetByIdJobRequest(int id, bool trackChanges = false) => GetById(id,trackChanges);
   

    public void UpdateJobRequest(JobRequest entity) => Update(entity);


}
