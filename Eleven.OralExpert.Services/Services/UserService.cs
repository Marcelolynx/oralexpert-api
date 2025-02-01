using Eleven.OralExpert.Core.Utilities;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Infra.Interfaces;
using Eleven.OralExpert.Services.Interfaces;

namespace Eleven.OralExpert.Services.Services;
public class UserService : GenericService<User>, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }
 
    public void UpdateUser(Guid id, string? name, string? password)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            user.UpdateName(name);
        }

        if (!string.IsNullOrWhiteSpace(password))
        {
            user.UpdatePassword(PasswordHasher.HashPassword(password));
        }

        user.UpdatedAtNow();
        _userRepository.Update(user);
    }


}