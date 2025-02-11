namespace Harfiyat_DataAccess.Contracts;

public interface IRepositoryManager
{
    IJobRequestReepository JobRequestRepository {get;}
    IJobRepository JobRepository {get;}

    void SaveChanges();
}
