namespace MetalERP.Application.Features.Setores.GetSetorRead;

public record GetSetorReadResponse(
    int Id,
    string Nome,
    string? TelSetor,
    bool Ativo
);