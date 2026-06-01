namespace MetalERP.Domain.Entities;

public class Setor
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string? Tel_Setor { get; private set; } = string.Empty;

    public bool Ativo { get; private set; } = true;

    public ICollection<Usuario> Usuarios { get; private set; }
    = new List<Usuario>();

    private Setor()
    {
    }

    public static Setor Create(
        string nome,
        string? telSetor)
    {
        ArgumentException
        .ThrowIfNullOrWhiteSpace(nome);

        return new Setor
        {
            Nome = nome,
            Tel_Setor = telSetor
        };
    }

    public void Atualizar(
        string nome,
        string telSetor)
    {
        Nome = nome;
        Tel_Setor = telSetor;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}