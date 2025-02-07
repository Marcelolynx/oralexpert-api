namespace Eleven.OralExpert.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Referência ao usuário do sistema
    public User User { get; set; }

    public string Position { get; set; } // Exemplo: Recepcionista, Gerente
}