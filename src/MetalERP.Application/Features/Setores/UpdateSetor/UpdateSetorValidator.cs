using FluentValidation;

namespace MetalERP.Application.Features.Setores.UpdateSetor;

public class UpdateSetorValidator
    : AbstractValidator<UpdateSetorCommand>
{
    public UpdateSetorValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id inválido.");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do setor é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O nome do setor deve ter no máximo 100 caracteres.");

        RuleFor(x => x.TelSetor)
            .MaximumLength(20)
            .WithMessage("O telefone deve ter no máximo 20 caracteres.");
    }
}