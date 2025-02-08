using AspNetCore.IQueryable.Extensions;
using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.Core.Utilities;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Eleven.OralExpert.Services.DTOs;
using Eleven.OralExpert.Services.Filters;
using Eleven.OralExpert.Services.Validators;
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
        var validator = new UserRegisterDtoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(new { Errors = validationResult.Errors.Select(e => e.ErrorMessage) });
        }
        try
        {
            var userResponse = _userService.RegisterUser(request);

            return Created("", new
            {
                Message = "User created successfully!",
                User = userResponse
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Errors = new[] { ex.Message } });
        }
    }

    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<UserResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [SwaggerOperation(
        Summary = "Lista usuários paginados",
        Description = "Retorna uma lista paginada de usuários aplicando filtros"
    )]
    public IActionResult ListUsers([FromQuery] UserQueryFilter filters, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "Name")
    {
        try
        {
            var users = _userService.ListUsers(filters, page, pageSize, orderBy);
            return Ok(users);
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
