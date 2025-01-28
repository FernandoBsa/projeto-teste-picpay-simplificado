using PicPaySimplificado.Domain.Enum;

namespace PicPaySimplificado.Domain.Entity;

public class CarteiraEntity
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal SaldoConta { get; set; }
    public Usertype UserType { get; set; }

    private CarteiraEntity()
    {

    }

    public CarteiraEntity(string nomeCompleto, string cpfcnpj, string email, string senha, Usertype userType,
        decimal saldoConta = 0)
    {
        NomeCompleto = nomeCompleto;
        CPFCNPJ = cpfcnpj;
        Email = email;
        Senha = senha;
        SaldoConta = saldoConta;
        UserType = userType;
    }

    public void DebitarSaldo(decimal valor)
    {
        SaldoConta -= valor;
    }

    public void CreditarSaldo(decimal valor)
    {
        SaldoConta += valor;
    }

}