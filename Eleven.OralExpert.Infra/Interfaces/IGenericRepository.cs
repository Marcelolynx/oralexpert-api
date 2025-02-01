using System.Linq.Expressions;

namespace Eleven.OralExpert.Infra.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> AsQueryable();
    Task<List<T>> GetAllAsQueryableAsync();
    IEnumerable<T> GetAll();
    IEnumerable<T> GetPaged(int page, int pageSize);

    T? GetById(Guid id);
    void Add(T entity);
    void Update(T entity);
    void SoftDelete(T entity);
    IEnumerable<T> GetAllNotDeleted();
}