using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.ActiveUsuario;

public class ActiveUsuarioHandler
    : IRequestHandler<
        ActiveUsuarioCommand,
        ActiveUsuarioResponse?>
{
    private readonly IUsuarioRepository _repository;

    public ActiveUsuarioHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActiveUsuarioResponse?> Handle(
        ActiveUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var usuario =
            await _repository.GetByIdAsync(
                request.Id);

        if (usuario is null)
        {
            return null;
        }

        usuario.Ativar();

        await _repository.UpdateAsync(usuario);

        return new ActiveUsuarioResponse(
            usuario.Id,
            usuario.Ativo
        );
    }
}