using MediatR;
using MetalERP.Application.Contracts;

namespace MetalERP.Application.Features.Usuarios.GetUsuarios;

public class GetUsuariosHandler
    : IRequestHandler<
        GetUsuariosQuery,
        List<GetUsuariosResponse>>
{
    private readonly IUsuarioRepository _repository;

    public GetUsuariosHandler(
        IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetUsuariosResponse>> Handle(
        GetUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var usuarios =
            await _repository.GetAllAsync();

        return usuarios
            .Select(u => new GetUsuariosResponse(
                u.Id,
                u.Nome,
                u.Email,
                u.Setor.Nome,
                u.Ativo
            ))
            .ToList();
    }
}