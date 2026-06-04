namespace MetalERP.Application.Features.Usuarios.CreateUsuario;

public record CreateUsuarioResponse(
    int Id,
    string Nome,
    string Email,
    int Setor_Id
);