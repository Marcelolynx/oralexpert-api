using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Interfaces;

public interface IUserRepository  : IGenericRepository<User>
{ 
    User GetByEmail(string email);
}