using MediatR;

namespace MetalERP.Application.Features.Usuarios.GetUsuarioRead;

public record GetUsuarioReadQuery(int Id)
    : IRequest<GetUsuarioReadResponse?>;