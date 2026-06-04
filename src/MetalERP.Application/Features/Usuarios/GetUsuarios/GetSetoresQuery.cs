using MediatR;

namespace MetalERP.Application.Features.Usuarios.GetUsuarios;

public record GetUsuariosQuery()
    : IRequest<List<GetUsuariosResponse>>;