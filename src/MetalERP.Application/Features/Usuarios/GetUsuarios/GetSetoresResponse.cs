namespace MetalERP.Application.Features.Usuarios.GetUsuarios;

public record GetUsuariosResponse(
    int Id,
    string Nome,
    string Email,
    string Setor,
    bool Ativo
);