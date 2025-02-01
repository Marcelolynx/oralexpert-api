using System.ComponentModel.DataAnnotations;
using Eleven.OralExpert.Core.Notifications;
using Eleven.OralExpert.Domain.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Eleven.OralExpert.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsDeleted { get; private set; }
    
    public Guid ClinicId { get; private set; }
    
    public Clinic Clinic { get; private set; }

    public User(string name, string email, string password,  Guid clinicId)
    {
        Name = name;
        Email = email;
        Password = password;
        IsDeleted = false;
        ClinicId = clinicId;

        CreatedAtNow();
        Validate();
    }
    
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        Name = name;
    }

    public void UpdatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }
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