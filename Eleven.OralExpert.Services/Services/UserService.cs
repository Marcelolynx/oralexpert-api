using AspNetCore.IQueryable.Extensions;
using AutoMapper;
using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.API.Filters;
using Eleven.OralExpert.Core.Utilities;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Domain.Factories;
using Eleven.OralExpert.Infra.Interfaces;
using Eleven.OralExpert.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Eleven.OralExpert.Services.Services;
public class UserService : GenericService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly string _defaultClinicId;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper) : base(userRepository)
    {
        _userRepository = userRepository;
        _defaultClinicId = configuration["DefaultClinicId"];
        _mapper = mapper;
    }


    public UserResponseDto RegisterUser(UserRegisterDto request)
    {
        var existingUser = _userRepository.GetByEmail(request.Email);
        if (existingUser != null)
            throw new Exception("Email já está em uso");

        var hashedPassword = PasswordHasher.HashPassword(request.Password);
        var user = UserFactory.CreateUser(request.Name, request.Email, hashedPassword, Guid.Parse(_defaultClinicId), request.Role);
        
        Add(user);

        var userResponseDto = _mapper.Map<UserResponseDto>(user);
        
        return userResponseDto;
    }

    public PagedResult<UserResponseDto> ListUsers(UserQueryFilter filters, int page, int pageSize, string orderBy)
    {
        var query = _userRepository.AsQueryable();
        
        query = query.Apply(filters);

        query = orderBy.ToLower() switch
        {
            "email" => query.OrderBy(u => u.Email),
            "createdat" => query.OrderBy(u => u.CreatedAt),
            _ => query.OrderBy(u => u.Name)
        };

        var totalCount = query.Count();

        var pagedResult = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var userDtos = pagedResult.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        }).ToList();

        return new PagedResult<UserResponseDto>(userDtos, page, pageSize, totalCount);
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