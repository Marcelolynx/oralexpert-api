namespace Eleven.OralExpert.API.DTOs;

public class ClinicCreateDto
{
    public string NomeMarca { get; set; }
    public string RazaoSocial { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Logomarca { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string ResponsavelTecnico { get; set; }
    public int TipoPessoa { get; set; } 
}