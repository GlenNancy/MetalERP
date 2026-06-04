using FluentValidation;

namespace MetalERP.Application.Features.Usuarios.UpdateUsuario;

public class UpdateUsuarioValidator
    : AbstractValidator<UpdateUsuarioCommand>
{
    public UpdateUsuarioValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id inválido.");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do usuário é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O nome do usuário deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email do usuário é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O email do usuário deve ter no máximo 100 caracteres.");

        RuleFor(x => x.SenhaHash)
            .NotEmpty()
            .WithMessage("A senha do usuário é obrigatória.")
            .MaximumLength(255)
            .WithMessage("A senha do usuário deve ter no máximo 255 caracteres.");
    }
}