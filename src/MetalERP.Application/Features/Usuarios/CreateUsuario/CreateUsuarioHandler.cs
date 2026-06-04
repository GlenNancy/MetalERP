using MediatR;
using MetalERP.Application.Contracts;
using MetalERP.Domain.Entities;

namespace MetalERP.Application.Features.Usuarios.CreateUsuario;

public class CreateUsuarioHandler
    : IRequestHandler<CreateUsuarioCommand, CreateUsuarioResponse>
{
    private readonly IUsuarioRepository _repository;

    public CreateUsuarioHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateUsuarioResponse> Handle(
        CreateUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var usuario = Usuario.Create(
            request.Nome,
            request.Email,
            request.SenhaHash,
            request.Setor_Id
        );

        await _repository.AddAsync(usuario);

        return new CreateUsuarioResponse(
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.Setor_Id
        );
    }
}