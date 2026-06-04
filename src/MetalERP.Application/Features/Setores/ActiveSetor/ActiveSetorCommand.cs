using MediatR;

namespace MetalERP.Application.Features.Setores.ActivateSetor;

public record ActivateSetorCommand(
    int Id)
    : IRequest<ActivateSetorResponse?>;