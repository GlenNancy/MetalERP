using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.GetUsuario;

public class GetUsuarioHandler
    : IRequestHandler<
        GetUsuarioQuery,
        GetUsuarioResponse?>
{
    private readonly IUsuarioRepository _repository;

    public GetUsuarioHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

     public async Task<GetUsuarioResponse?> Handle(
        GetUsuarioQuery request,
        CancellationToken cancellationToken)    {
        var usuario =
            await _repository.GetByIdReadOnlyAsync(request.Id);

        if (usuario is null)
            return null;

        return new GetUsuarioResponse(
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.Setor.Nome
        );
    }
}