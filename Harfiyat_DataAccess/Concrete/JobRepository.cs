using System.Linq.Expressions;
using Harfiyat_DataAccess.Context;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Harfiyat_DataAccess.Concrete;

public class JobRepository :BaseRepository<Job>, IJobRepository
{
    
    public JobRepository(ConsturactionContext context) : base(context)
    {
        
    }

    public void AddJob(Job entity) => Add(entity);

    public void DeleteJob(Job entity) => Delete(entity);


    public IEnumerable<Job> GetAllJob(bool trackChanges = false) => GetAll(trackChanges);

    public IEnumerable<Job> GetAllWithConditionJob(Expression<Func<Job, bool>> expression, bool trackChanges = false)
    =>GetAllWithCondition(expression,trackChanges);

    public Job? GetByIdJob(int id, bool trackChanges = false) => GetById(id,trackChanges);


    public void UpdateJob(Job entity) => Update(entity);
  

}
