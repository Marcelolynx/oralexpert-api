using System.Linq.Expressions;
using Eleven.OralExpert.Infra.Data;
using Eleven.OralExpert.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eleven.OralExpert.Infra.Repository;

public class GenericRepository<T> :  IQueryableRepository<T>, IGenericRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;


    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null ? _dbSet.AsNoTracking().ToList() : _dbSet.AsNoTracking().Where(predicate).ToList();
        
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetPaged(int page, int pageSize)
    {
        if (page < 1 || pageSize < 1)
        {
            throw new ArgumentException("Page and PageSize must be greater than 0.");
        }

        return _dbSet.AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public T? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public virtual void SoftDelete(T entity)
    {
        var property = typeof(T).GetProperty("IsDeleted");
        if (property != null && property.PropertyType == typeof(bool))
        {
            property.SetValue(entity, true);
            _context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException($"Entity {typeof(T).Name} não foi deletada.");
        }
    }
    
    public virtual IEnumerable<T> GetAllNotDeleted()
    {
        var property = typeof(T).GetProperty("IsDeleted");
        if (property != null && property.PropertyType == typeof(bool))
        {
            return _dbSet.AsNoTracking().Where(e => !(bool)property.GetValue(e)!).ToList();
        }

        return _dbSet.AsNoTracking().ToList();
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<List<T>> GetAllAsQueryableAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }
}