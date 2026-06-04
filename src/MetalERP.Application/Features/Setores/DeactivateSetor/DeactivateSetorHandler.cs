using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Setores.DeactivateSetor;

public class DeactivateSetorHandler
    : IRequestHandler<
        DeactivateSetorCommand,
        DeactivateSetorResponse?>
{
    private readonly ISetorRepository _repository;

    public DeactivateSetorHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeactivateSetorResponse?> Handle(
        DeactivateSetorCommand request,
        CancellationToken cancellationToken)
    {
        var setor =
            await _repository.GetByIdAsync(
                request.Id);

        if (setor is null)
        {
            return null;
        }

        setor.Desativar();

        await _repository.UpdateAsync(setor);

        return new DeactivateSetorResponse(
            setor.Id,
            setor.Ativo
        );
    }
}