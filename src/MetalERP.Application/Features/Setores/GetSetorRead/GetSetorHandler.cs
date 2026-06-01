using MediatR;
using MetalERP.Application.Contracts;
using MetalERP.Application.Features.Setores.GetSetorRead;

namespace MetalERP.Application.Features.Setores.GetSetorRead;

public class GetSetorReadHandler
    : IRequestHandler<
        GetSetorReadQuery,
        GetSetorReadResponse?>
{
    private readonly ISetorRepository _repository;

    public GetSetorReadHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

     public async Task<GetSetorReadResponse?> Handle(
        GetSetorReadQuery request,
        CancellationToken cancellationToken)    {
        var setor =
            await _repository.GetByIdReadOnlyAsync(request.Id);

        if (setor is null)
            return null;

        return new GetSetorReadResponse(
            setor.Id,
            setor.Nome,
            setor.Tel_Setor,
            setor.Ativo
        );
    }
}