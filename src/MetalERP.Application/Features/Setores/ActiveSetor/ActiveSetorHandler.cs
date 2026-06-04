using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Setores.ActivateSetor;

public class ActivateSetorHandler
    : IRequestHandler<
        ActivateSetorCommand,
        ActivateSetorResponse?>
{
    private readonly ISetorRepository _repository;

    public ActivateSetorHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActivateSetorResponse?> Handle(
        ActivateSetorCommand request,
        CancellationToken cancellationToken)
    {
        var setor =
            await _repository.GetByIdAsync(
                request.Id);

        if (setor is null)
        {
            return null;
        }

        setor.Ativar();

        await _repository.UpdateAsync(setor);

        return new ActivateSetorResponse(
            setor.Id,
            setor.Ativo
        );
    }
}