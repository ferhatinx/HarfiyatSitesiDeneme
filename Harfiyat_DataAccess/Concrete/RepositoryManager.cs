using Harfiyat_DataAccess.Context;
using Harfiyat_DataAccess.Contracts;

namespace Harfiyat_DataAccess.Concrete;

public class RepositoryManager : IRepositoryManager
{
    private readonly IJobRequestReepository _jobRequestReepository;
    private readonly ConsturactionContext _context;
    private readonly IJobRepository _jobRepository;
    public RepositoryManager(IJobRequestReepository jobRequestReepository, ConsturactionContext context, IJobRepository jobRepository)
    {
        _jobRequestReepository = jobRequestReepository;
        _context = context;
        _jobRepository = jobRepository;
    }


    public IJobRequestReepository JobRequestRepository => _jobRequestReepository;

    public IJobRepository JobRepository => _jobRepository;


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
