using MediatR;

namespace MetalERP.Application.Features.Setores.CreateSetor;

public record CreateSetorCommand(
    string Nome,
    string? TelSetor
) : IRequest<CreateSetorResponse>;