using MediatR;

namespace MetalERP.Application.Features.Usuarios.CreateUsuario;

public record CreateUsuarioCommand(
    string Nome,
    string Email,
    string SenhaHash,
    int Setor_Id
) : IRequest<CreateUsuarioResponse>;