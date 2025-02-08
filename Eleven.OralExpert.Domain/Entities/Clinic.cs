using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Entities;

public class Clinic : BaseEntity
{
    public PersonType PersonType { get; private set; }
    public string BrandName { get; private set; }
    public string CorporateName  { get; private set; }
    public Address Address  { get; private set; }
    public string Phone  { get; private set; }
    public string Logo  { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string TechnicalManager  { get; private set; }

    
    public Clinic(){}

    public Clinic(PersonType personType, string brandName, string corporateName, Address address, 
        string phone, string logo, string cnpj, string email, string technicalManager)
    {
        PersonType = personType;
        BrandName = brandName;
        CorporateName = corporateName;
        Address = address;
        Phone = phone;
        Logo = logo;
        Cnpj = cnpj;
        Email = email;
        TechnicalManager = technicalManager;
        CreatedAtNow();
    }
    
    public void UpdateData(string brandName, string corporateName, Address address, 
        string phone, string logo, string email, string technicalManager)
    {
        BrandName = brandName;
        CorporateName = corporateName;
        Address = address;
        Phone = phone;
        Logo = logo;
        Email = email;
        TechnicalManager = technicalManager;
        UpdatedAtNow(); // Atualiza a data de modificação
    }
    
}