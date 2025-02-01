using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Services.Interfaces;

public interface IUserService
{
    User? GetByEmail(string email);
    
    void UpdateUser(Guid id, string? name, string? password);
}