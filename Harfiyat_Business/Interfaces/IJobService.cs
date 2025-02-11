using System.Linq.Expressions;
using Harfiyat_Common.ResponseObjects;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Interfaces;

public interface IJobService 
{
    IResponse<IEnumerable<Job>> GetAllJob(bool trackChanges=false);

    IResponse<Job?> GetByIdJob(int id, bool trackChanges=false);

    IResponse AddJob(Job entity);

    IResponse UpdateJob(Job entity);

    IResponse DeleteJob(Job entity);

     public IResponse<IEnumerable<Job>> GetAllWithJobRequest(int jobRequestId,bool trackChanges = false);
}
