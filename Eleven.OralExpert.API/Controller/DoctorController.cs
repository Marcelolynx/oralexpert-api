using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Services.DTO;
using Eleven.OralExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Eleven.OralExpert.API.Controller;

public class DoctorController : ControllerBase
{
    private readonly ILogger<DoctorController> _logger;
    private readonly IGenericService<Doctor> _genericService;
    private readonly string _defaultClinicId;

    public DoctorController(ILogger<DoctorController> logger, IConfiguration configuration, IGenericService<Doctor> genericService)
    {
        _genericService = genericService;
        _defaultClinicId = configuration["DefaultClinicId"];
        _logger = logger;
    }

    [HttpPost]
    [Route("doctor-register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [SwaggerOperation(
        Summary = "Cadastra novo Dentista",
        Description = "Efetua cadastro de novo profissional da clínica."
    )]
    public async Task<IActionResult> Register([FromBody] DoctorRegisterDto request)
    {
        return Ok("Task Running...");
    }
}