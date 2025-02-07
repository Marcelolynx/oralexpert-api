namespace Eleven.OralExpert.Domain.Entities;

public class Address
{
    public Guid Id { get; private set; }
    
    public string Street { get; private set; }
    
    public string Neighborhood { get; private set; }
    
    public string City { get; private set; }
    
    public string ZipCode { get; private set; }
    
    public string State { get; private set; }
}