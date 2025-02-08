using Eleven.OralExpert.Domain.Enums;
using Eleven.OralExpert.Domain.Validators;
using FluentValidation.Results;

namespace Eleven.OralExpert.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; } // 🔥 Flag para ativar/desativar usuário

    public Guid ClinicId { get; private set; }
    public Clinic Clinic { get; private set; }
    public Role Role { get; private set; }

    public Address Address { get; private set; } // 🔥 Adicionado o endereço ao usuário

    protected User() { } // Construtor protegido para EF Core

    public User(string name, string email, string password, Guid clinicId, Role role, Address address)
    {
        Name = name;
        Email = email;
        Password = password;
        IsDeleted = false;
        IsActive = true; // 🔥 Usuário começa ativo
        ClinicId = clinicId;
        Role = role;
        Address = address ?? throw new ArgumentNullException(nameof(address)); // 🔥 Garantir que o endereço não seja nulo
        CreatedAtNow();

        Validate();
    }

    // 🔥 Método para alterar o endereço do usuário
    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
        UpdatedAtNow();
    }

    // 🔥 Método para ativar/desativar usuário
    public void SetActiveStatus(bool isActive)
    {
        IsActive = isActive;
        UpdatedAtNow();
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        Name = name;
    }

    public void UpdatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        Password = password;
    }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
        UpdatedAtNow();
    }

    private void Validate()
    {
        var validator = new UserValidator();
        ValidationResult result = validator.Validate(this);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                AddNotification(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
