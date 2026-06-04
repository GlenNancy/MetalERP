using MediatR;

namespace MetalERP.Application.Features.Setores.UpdateSetor;

public record UpdateSetorCommand(
    int Id,
    string Nome,
    string? TelSetor)
    : IRequest<UpdateSetorResponse>;