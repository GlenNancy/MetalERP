namespace MetalERP.Application.Features.Usuarios.GetUsuarioRead;

public record GetUsuarioReadResponse(
    int Id,
    string Nome,
    string Email,
    string Setor
);