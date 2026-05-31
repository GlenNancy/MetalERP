namespace MetalERP.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Senha_Hash { get; private set; } = string.Empty;

    public int Setor_Id { get; private set; }

    public bool Ativo { get; private set; }

    public Setor Setor { get; private set; } = null!;

    public DateTime Data_Criacao { get; private set; } // = DateTime.UtcNow;
}