using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Infra.Data;
using Eleven.OralExpert.Infra.Interfaces;

namespace Eleven.OralExpert.Infra.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    { }
    
    public User GetByEmail(string email)
    {
        return _dbSet.FirstOrDefault(u => u.Email == email);
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
}
