using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.API.DTOs;

public class ClinicResponseDto
{
    public Guid Id { get; set; }
    public string NomeMarca { get; set; }
    public string RazaoSocial { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string ResponsavelTecnico { get; set; }
    public TipoPessoa TipoPessoa { get; set; }
}