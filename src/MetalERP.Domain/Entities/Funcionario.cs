namespace MetalERP.Domain.Entities;

public class Funcionario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Codigo { get; private set; } = string.Empty;

    public string? Apelido { get; private set; } = string.Empty;

    public int Setor_Id { get; private set; }

    public Setor Setor { get; private set; } = null!;

    public bool Ativo { get; private set; } = true;

    public DateTime Data_Criacao { get; private set; } // = DateTime.UtcNow;

    private Funcionario()
    {
    }

    public static Funcionario Create(
        string nome,
        string? apelido,
        string codigo,
        int setor_Id)
    {
        ArgumentException
        .ThrowIfNullOrWhiteSpace(nome);
        ArgumentException
        .ThrowIfNullOrWhiteSpace(codigo);

        return new Funcionario
        {
            Nome = nome,
            Apelido = apelido,
            Codigo = codigo,
            Data_Criacao = DateTime.UtcNow,
            Setor_Id = setor_Id
        };
    }

    public void Atualizar(
        string nome,
        string? apelido,
        string codigo,
        int setor_Id)
    {
        Nome = nome;
        Apelido = apelido;
        Codigo = codigo;
        Setor_Id = setor_Id;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }
}