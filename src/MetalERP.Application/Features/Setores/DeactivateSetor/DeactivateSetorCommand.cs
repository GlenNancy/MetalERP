using MediatR;

namespace MetalERP.Application.Features.Setores.DeactivateSetor;

public record DeactivateSetorCommand(
    int Id)
    : IRequest<DeactivateSetorResponse?>;