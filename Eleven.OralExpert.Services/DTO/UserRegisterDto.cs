using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Services.DTOs;

public class UserRegisterDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    
    public Guid ClinicId { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
}