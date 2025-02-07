namespace Eleven.OralExpert.Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Referência ao usuário do sistema
    public User User { get; set; }
    public string CRO { get; set; } // Número do conselho regional de Odontologia opcional

    public string Especialidade { get; set; } // Exemplo: Ortodontia, Implantodontia
}
