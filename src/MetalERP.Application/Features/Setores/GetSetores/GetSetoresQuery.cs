using MediatR;

namespace MetalERP.Application.Features.Setores.GetSetores;

public record GetSetoresQuery()
    : IRequest<List<GetSetoresResponse>>;