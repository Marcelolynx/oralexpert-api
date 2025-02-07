using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.API.Filters;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Services.Interfaces;

public interface IUserService
{
    UserResponseDto RegisterUser(UserRegisterDto request);
    User? GetByEmail(string email);
    
    void UpdateUser(Guid id, string? name, string? password);
    PagedResult<UserResponseDto> ListUsers(UserQueryFilter filters, int page, int pageSize, string orderBy);
}