namespace MetalERP.Application.Features.Usuarios.UpdateUsuario;

public record UpdateUsuarioResponse(
    int Id,
    string Nome,
    string Email,
    string SenhaHash
);