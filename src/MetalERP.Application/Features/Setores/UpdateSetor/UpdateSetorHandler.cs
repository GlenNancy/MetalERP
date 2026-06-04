using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Setores.UpdateSetor;

public class UpdateSetorHandler
    : IRequestHandler<
        UpdateSetorCommand,
        UpdateSetorResponse?>
{
    private readonly ISetorRepository _repository;

    public UpdateSetorHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateSetorResponse?> Handle(
        UpdateSetorCommand request,
        CancellationToken cancellationToken)
    {
        var setor =
            await _repository.GetByIdAsync(
                request.Id);

        if (setor is null)
        {
            return null;
        }

        setor.Atualizar(
            request.Nome,
            request.TelSetor);

        await _repository.UpdateAsync(setor);

        return new UpdateSetorResponse(
            setor.Id,
            setor.Nome,
            setor.Tel_Setor,
            setor.Ativo
        );
    }
}