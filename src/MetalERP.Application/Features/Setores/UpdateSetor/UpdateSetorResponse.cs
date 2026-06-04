namespace MetalERP.Application.Features.Setores.UpdateSetor;

public record UpdateSetorResponse(
    int Id,
    string Nome,
    string? TelSetor,
    bool Ativo
);