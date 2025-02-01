using Eleven.OralExpert.Infra.Interfaces;
using Eleven.OralExpert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eleven.OralExpert.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _repository.AsQueryable();
        }

        public async Task<List<T>> GetAllAsQueryableAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAllNotDeleted();
        }

        public IEnumerable<T> GetPaged(int page, int pageSize)
        {
            if (page < 1 || pageSize < 1)
            {
                throw new ArgumentException("Page ande PageSize must be greater tahn 0.");
            }

            return _repository.GetPaged(page, pageSize);
        }

        public T? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void SoftDelete(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                _repository.SoftDelete(entity);
            }
        }

      
    }
}
