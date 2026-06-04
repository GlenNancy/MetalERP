using MediatR;

namespace MetalERP.Application.Features.Usuarios.DeactivateUsuario;

public record DeactivateUsuarioCommand(
    int Id)
    : IRequest<DeactivateUsuarioResponse?>;