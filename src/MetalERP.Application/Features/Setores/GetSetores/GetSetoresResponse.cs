namespace MetalERP.Application.Features.Setores.GetSetores;

public record GetSetoresResponse(
    int Id,
    string Nome,
    string? TelSetor,
    bool Ativo
);