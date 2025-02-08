using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Entities;

public class Patient : User
{
    public string MedicalRecord { get; private set; }

    private Patient() { } // Construtor protegido para o EF Core

    public Patient(string name, string email, string password, Guid clinicId, Address address, string medicalRecord)
        : base(name, email, password, clinicId, Role.Patient, address) // 🔥 Chama o construtor do User
    {
        MedicalRecord = string.IsNullOrWhiteSpace(medicalRecord) ? throw new ArgumentException("Histórico médico não pode ser vazio.") : medicalRecord;
    }
}