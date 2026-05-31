using MediatR;
using MetalERP.Application.Contracts;
using MetalERP.Domain.Entities;

namespace MetalERP.Application.Features.Setores.CreateSetor;

public class CreateSetorHandler
    : IRequestHandler<CreateSetorCommand, CreateSetorResponse>
{
    private readonly ISetorRepository _repository;

    public CreateSetorHandler(
        ISetorRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateSetorResponse> Handle(
        CreateSetorCommand request,
        CancellationToken cancellationToken)
    {
        var setor = Setor.Create(
            request.Nome,
            request.TelSetor
        );

        await _repository.AddAsync(setor);

        return new CreateSetorResponse(
            setor.Id,
            setor.Nome
        );
    }
}