using MediatR;

namespace MetalERP.Application.Features.Setores.GetSetorRead;

public record GetSetorReadQuery(int Id)
    : IRequest<GetSetorReadResponse?>;