using MediatR;

namespace MetalERP.Application.Features.Usuarios.GetUsuario;

public record GetUsuarioQuery(int Id)
    : IRequest<GetUsuarioResponse?>;