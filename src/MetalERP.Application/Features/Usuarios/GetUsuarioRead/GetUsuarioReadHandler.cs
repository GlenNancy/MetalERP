using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.GetUsuarioRead;

public class GetUsuarioReadHandler
    : IRequestHandler<
        GetUsuarioReadQuery,
        GetUsuarioReadResponse?>
{
    private readonly IUsuarioRepository _repository;

    public GetUsuarioReadHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

     public async Task<GetUsuarioReadResponse?> Handle(
        GetUsuarioReadQuery request,
        CancellationToken cancellationToken)    {
        var usuario =
            await _repository.GetByIdReadOnlyAsync(request.Id);

        if (usuario is null)
            return null;

        return new GetUsuarioReadResponse(
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.Setor.Nome
        );
    }
}