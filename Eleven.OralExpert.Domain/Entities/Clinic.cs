using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Entities;

public class Clinic : BaseEntity
{
    public TipoPessoa TipoPessoa { get; private set; }
    public string NomeMarca { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Endereco { get; private set; }
    public string Telefone { get; private set; }
    public string Logomarca { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string ResponsavelTecnico { get; private set; }


    public Clinic(TipoPessoa tipoPessoa, string nomeMarca, string razaoSocial, string endereco, string telefone, string logomarca,
        string cnpj, string email, string responsavelTecnico)
    {
        TipoPessoa = tipoPessoa;
        NomeMarca = nomeMarca;
        RazaoSocial = razaoSocial;
        Endereco = endereco;
        Telefone = telefone;
        Logomarca = logomarca;
        Cnpj = cnpj;
        Email = email;
        ResponsavelTecnico = responsavelTecnico;
        CreatedAtNow();
    }
    
    public void AtualizarDados(string nomeMarca, string razaoSocial, string endereco, string telefone, string logomarca, string email, string responsavelTecnico)
    {
        NomeMarca = nomeMarca;
        RazaoSocial = razaoSocial;
        Endereco = endereco;
        Telefone = telefone;
        Logomarca = logomarca;
        Email = email;
        ResponsavelTecnico = responsavelTecnico;
        UpdatedAtNow(); // Atualiza a data de modificação
    }
    
}