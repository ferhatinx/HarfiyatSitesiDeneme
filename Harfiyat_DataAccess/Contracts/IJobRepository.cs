using System.Linq.Expressions;
using Harfiyat_Entities.Entities;

namespace Harfiyat_DataAccess.Contracts;

public interface IJobRepository
{
    IEnumerable<Job> GetAllJob(bool trackChanges=false);

    Job? GetByIdJob(int id, bool trackChanges=false);

    void AddJob(Job entity);

    void UpdateJob(Job entity);

    void DeleteJob(Job entity);
    public IEnumerable<Job> GetAllWithConditionJob(Expression<Func<Job, bool>> expression, bool trackChanges = false);
}
