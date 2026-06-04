using FluentValidation;

namespace MetalERP.Application.Features.Usuarios.CreateUsuario;

public class CreateUsuarioValidator
    : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do usuário é obrigatório.")
            .MaximumLength(150)
            .WithMessage("O nome do usuário deve ter no máximo 150 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email do usuário é obrigatório.")
            .EmailAddress()
            .WithMessage("O email do usuário é inválido.");

        RuleFor(x => x.SenhaHash)
            .NotEmpty()
            .WithMessage("A senha do usuário é obrigatória.")
            .MinimumLength(6)
            .WithMessage("A senha do usuário deve ter no mínimo 6 caracteres.")
            .MaximumLength(100)
            .WithMessage("A senha do usuário deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Setor_Id)
            .NotEmpty()
            .WithMessage("O setor do usuário é obrigatório.");
            
    }
}