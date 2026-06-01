using MediatR;
using MetalERP.Application.Contracts;
using MetalERP.Application.Features.Setores.GetSetor;

namespace MetalERP.Application.Features.Setores.GetSetor;

public class GetSetorHandler
    : IRequestHandler<
        GetSetorQuery,
        GetSetorResponse?>
{
    private readonly ISetorRepository _repository;

    public GetSetorHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

     public async Task<GetSetorResponse?> Handle(
        GetSetorQuery request,
        CancellationToken cancellationToken)    {
        var setor =
            await _repository.GetByIdAsync(request.Id);

        if (setor is null)
            return null;

        return new GetSetorResponse(
            setor.Id,
            setor.Nome,
            setor.Tel_Setor,
            setor.Ativo
        );
    }
}