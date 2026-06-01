namespace MetalERP.Application.Features.Setores.GetSetor;

public record GetSetorResponse(
    int Id,
    string Nome,
    string? TelSetor,
    bool Ativo
);