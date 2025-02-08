using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.API.DTOs;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Role  Role { get; set; }
    
    public Guid ClinicId { get; set; }
    
    public bool IsDeleted { get;  set; }
}