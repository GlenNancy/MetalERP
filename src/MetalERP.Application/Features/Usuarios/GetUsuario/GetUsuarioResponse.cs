namespace MetalERP.Application.Features.Usuarios.GetUsuario;

public record GetUsuarioResponse(
    int Id,
    string Nome,
    string Email,
    string Setor
);