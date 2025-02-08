using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Entities;

public class Employee : User
{
    public string Position { get; private set; }
    public decimal Salary { get; private set; }

    private Employee() { } // Construtor protegido para o EF Core

    public Employee(string name, string email, string password, Guid clinicId, Address address, string position, decimal salary)
        : base(name, email, password, clinicId, Role.Employee, address) // 🔥 Chama o construtor do User
    {
        Position = string.IsNullOrWhiteSpace(position) ? throw new ArgumentException("Cargo não pode ser vazio.") : position;
    }
}