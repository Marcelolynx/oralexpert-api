using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Entities;

public class Doctor : User
{
    public string CRO { get; private set; }
    public string Specialty { get; private set; }

    private Doctor() { } // Construtor protegido para o EF Core

    public Doctor(string name, string email, string password, Guid clinicId, Address address, string cro, string specialty)
        : base(name, email, password, clinicId, Role.Doctor, address) // 🔥 Agora Role.Doctor está explícito!
    {
        CRO = string.IsNullOrWhiteSpace(cro) ? throw new ArgumentException("CRO não pode ser vazio.") : cro;
        Specialty = string.IsNullOrWhiteSpace(specialty) ? throw new ArgumentException("Especialidade não pode ser vazia.") : specialty;
    }
}