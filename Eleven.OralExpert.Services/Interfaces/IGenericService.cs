namespace Eleven.OralExpert.Services.Interfaces;

public interface IGenericService<T> where T : class
{
    IQueryable<T> GetAllAsQueryable();
    Task<List<T>> GetAllAsQueryableAsync();
    IEnumerable<T> GetAll();

    IEnumerable<T> GetPaged(int page, int pageSize);
    T? GetById(Guid id);
    void Add(T entity);
    void Update(T entity);
    void SoftDelete(Guid id);
}