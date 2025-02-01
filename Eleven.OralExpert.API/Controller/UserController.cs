using AspNetCore.IQueryable.Extensions;
using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.Core.Utilities;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Eleven.OralExpert.API.Filters;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Eleven.OralExpert.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IGenericService<User> _genericService;
    private readonly IGenericService<Clinic> _clinicGenericService;
    private readonly IUserService _userService;
    private readonly string _defaultClinicId;
    
    public UserController(
        ILogger<UserController> logger, 
        IConfiguration configuration,
        IGenericService<User> genericService,
        IGenericService<Clinic> clinicGenericService, 
        IUserService userService)
    {
        _genericService = genericService;
        _clinicGenericService = clinicGenericService;
        _userService = userService;
        _defaultClinicId = configuration["DefaultClinicId"];
        _logger = logger;
    }
     
    
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [SwaggerOperation(
        Summary = "Cadastra novo usuário",
        Description = "Efetua cadastro de novo usuário"
    )]
    public IActionResult Register([FromBody] UserRegisterDto request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return BadRequest(new { Errors = errors });
        }
       
        var existingUser = _userService.GetByEmail(request.Email);
        if (existingUser != null)
        {
            return BadRequest(new { Errors = new[] { "Email is already in use." } });
        }

       
        var hashedPassword = PasswordHasher.HashPassword(request.Password);
        var user = new User(request.Name, request.Email, hashedPassword, Guid.Parse(_defaultClinicId));

        _genericService.Add(user);

        return Created("", new { Message = "User created successfully!" });
    }

    [HttpGet]
    [Route("list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [SwaggerOperation(
        Summary = "Lista todos os usuários",
        Description = "Retorna uma lista paginada de usuários com filtros e ordenação."
    )]
    public async Task<IActionResult> ListUsers(
        [FromQuery] UserQueryFilter filters,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string orderBy = "Name"
    )
    {
        try
        {
            var query = _genericService.GetAllAsQueryable();
            
            query = query.Apply(filters);
            
            query = orderBy.ToLower() switch
            {
                "email" => query.OrderBy(u => u.Email),
                "createdat" => query.OrderBy(u => u.CreatedAt),
                _ => query.OrderBy(u => u.Name) 
            };
           
            var pagedResult = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
           
            var userDtos = pagedResult.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
            
            return Ok(new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = await query.CountAsync(),
                Data = userDtos
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }
    
    [HttpPatch]
    [Route("update/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [SwaggerOperation(
        Summary = "Update de usuário",
        Description = "Faz update de usuário, nome e senha."
    )]
    public IActionResult UpdateUser(Guid id, [FromBody] UserUpdateDto request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return BadRequest(new { Errors = errors });
        }

        try
        {
            _userService.UpdateUser(id, request.Name, request.Password);
            return Ok(new { Message = "User updated successfully!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }



    
}
