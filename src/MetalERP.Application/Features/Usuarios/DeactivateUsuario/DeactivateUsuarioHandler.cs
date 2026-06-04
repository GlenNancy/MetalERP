using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.DeactivateUsuario;

public class DeactivateUsuarioHandler
    : IRequestHandler<
        DeactivateUsuarioCommand,
        DeactivateUsuarioResponse?>
{
    private readonly IUsuarioRepository _repository;

    public DeactivateUsuarioHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeactivateUsuarioResponse?> Handle(
        DeactivateUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var usuario =
            await _repository.GetByIdAsync(
                request.Id);

        if (usuario is null)
        {
            return null;
        }

        usuario.Desativar();

        await _repository.UpdateAsync(usuario);

        return new DeactivateUsuarioResponse(
            usuario.Id,
            usuario.Ativo
        );
    }
}