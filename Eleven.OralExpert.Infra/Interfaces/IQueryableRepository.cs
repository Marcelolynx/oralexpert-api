namespace Eleven.OralExpert.Infra.Interfaces;

public interface IQueryableRepository<T> where T : class
{
    IQueryable<T> AsQueryable();
    Task<List<T>> GetAllAsQueryableAsync();
}