using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Setores.GetSetores;

public class GetSetoresHandler
    : IRequestHandler<
        GetSetoresQuery,
        List<GetSetoresResponse>>
{
    private readonly ISetorRepository _repository;

    public GetSetoresHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSetoresResponse>> Handle(
        GetSetoresQuery request,
        CancellationToken cancellationToken)
    {
        var setores =
            await _repository.GetAllAsync();

        return setores
            .Select(s => new GetSetoresResponse(
                s.Id,
                s.Nome,
                s.Tel_Setor,
                s.Ativo
            ))
            .ToList();
    }
}