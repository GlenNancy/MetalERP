using MediatR;

namespace MetalERP.Application.Features.Setores.GetSetor;

public record GetSetorQuery(int Id)
    : IRequest<GetSetorResponse?>;