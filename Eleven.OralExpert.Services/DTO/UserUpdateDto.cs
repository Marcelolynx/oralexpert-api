using Eleven.OralExpert.Core.Utilities;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.API.DTOs;
public class UserUpdateDto
{
    public string? Name { get; set; }
    public string? Password { get; set; }

    // Método para gerar os dados do domínio
    public void UpdateEntity(User user)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            user.UpdateName(Name);
        }

        if (!string.IsNullOrWhiteSpace(Password))
        {
            user.UpdatePassword(PasswordHasher.HashPassword(Password));
        }
    }
}