using MediatR;

namespace MetalERP.Application.Features.Usuarios.ActiveUsuario;

public record ActiveUsuarioCommand(
    int Id)
    : IRequest<ActiveUsuarioResponse?>;