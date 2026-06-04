using MediatR;

namespace MetalERP.Application.Features.Usuarios.UpdateUsuario;

public record UpdateUsuarioCommand(
    int Id,
    string Nome,
    string Email,
    string SenhaHash)
    : IRequest<UpdateUsuarioResponse>;