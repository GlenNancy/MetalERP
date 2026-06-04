using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.UpdateUsuario;

public class UpdateUsuarioHandler
    : IRequestHandler<
        UpdateUsuarioCommand,
        UpdateUsuarioResponse?>
{
    private readonly IUsuarioRepository _repository;

    public UpdateUsuarioHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateUsuarioResponse?> Handle(
        UpdateUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var usuario =
            await _repository.GetByIdAsync(
                request.Id);

        if (usuario is null)
        {
            return null;
        }

        usuario.Atualizar(
            request.Nome,
            request.Email,
            request.SenhaHash);

        await _repository.UpdateAsync(usuario);

        return new UpdateUsuarioResponse(
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.Senha_Hash
        );
    }
}