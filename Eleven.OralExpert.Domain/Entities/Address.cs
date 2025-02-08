using System.ComponentModel.DataAnnotations;
using Eleven.OralExpert.Core.Notifications;
using Eleven.OralExpert.Domain.Validators;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Eleven.OralExpert.Domain.Entities;

public class Address : Notifiable
{
    public string Street { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string State { get; private set; }
    
    private Address() { }
    
    public Address(string street, string neighborhood, string city, string zipCode, string state)
    {
       
        Street = street;
        Neighborhood = neighborhood;
        City = city;
        ZipCode = zipCode;
        State = state;

        Validate(); 
    }
    
    private void Validate()
    {
        var validator = new AddressValidator();
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
