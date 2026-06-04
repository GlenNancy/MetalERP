namespace MetalERP.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Senha_Hash { get; private set; } = string.Empty;

    public int Setor_Id { get; private set; }

    public Setor Setor { get; private set; } = null!;

    public bool Ativo { get; private set; }

    public DateTime Data_Criacao { get; private set; } // = DateTime.UtcNow;

    private Usuario()
    {
    }

    public static Usuario Create(
        string nome,
        string email,
        string senhaHash,
        int setor_Id)
    {
        ArgumentException
        .ThrowIfNullOrWhiteSpace(nome);
        ArgumentException
        .ThrowIfNullOrWhiteSpace(email);
        ArgumentException
        .ThrowIfNullOrWhiteSpace(senhaHash);

        return new Usuario
        {
            Nome = nome,
            Email = email,
            Senha_Hash = senhaHash,
            Setor_Id = setor_Id,
            Data_Criacao = DateTime.UtcNow
        };
    }

    public void Atualizar(
        string nome,
        string email,
        string senhaHash)
    {
        Nome = nome;
        Email = email;
        Senha_Hash = senhaHash;
    }

    public void AtualizarSetor(
        int setorId)
    {
        Setor_Id = setorId;
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