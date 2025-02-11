
using System.Linq.Expressions;
using Harfiyat_Entities.Entities;

namespace Harfiyat_DataAccess.Contracts;

public interface IBaseRepository<T> where T : BaseEntitiy
{
    IEnumerable<T> GetAll(bool trackChanges = false);
    IQueryable<T> GetQuery(bool trackChanges = false);

    T? GetById(int id, bool trackChanges = false);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool trackChanges = false);
    IEnumerable<T> GetAllWithCondition(Expression<Func<T,bool>> expression,bool trackChanges = false);

}
