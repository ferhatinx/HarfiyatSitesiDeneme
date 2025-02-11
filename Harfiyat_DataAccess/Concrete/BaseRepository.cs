using System.Linq.Expressions;
using Harfiyat_DataAccess.Context;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harfiyat_DataAccess.Concrete;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntitiy
{
    private readonly ConsturactionContext _context;

    public BaseRepository(ConsturactionContext context)
    {
        _context = context;
    }


    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool trackChanges = false)
    {
        return trackChanges ? _context.Set<T>().Where(predicate) : _context.Set<T>().Where(predicate).AsNoTracking() ;
    }

    public IQueryable<T> GetQuery(bool trackChanges = false)
    {
       return  trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public T? GetById(int id, bool trackChanges = false)
    {
        return trackChanges ? _context.Set<T>().FirstOrDefault(x=>x.Id == id) :_context.Set<T>().AsNoTracking().FirstOrDefault(x=>x.Id == id);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public IEnumerable<T> GetAll(bool trackChanges = false)
    {
       return  trackChanges ? _context.Set<T>().ToList() : _context.Set<T>().AsNoTracking().ToList();
    }

    public IEnumerable<T> GetAllWithCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
    {
        return  trackChanges ? _context.Set<T>().Where(expression).ToList() : _context.Set<T>().Where(expression).AsNoTracking().ToList();
    }

}
