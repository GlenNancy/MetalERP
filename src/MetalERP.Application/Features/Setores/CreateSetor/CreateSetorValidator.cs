using FluentValidation;

namespace MetalERP.Application.Features.Setores.CreateSetor;

public class CreateSetorValidator
    : AbstractValidator<CreateSetorCommand>
{
    public CreateSetorValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do setor é obrigatório.")
            .MaximumLength(150)
            .WithMessage("O nome do setor deve ter no máximo 150 caracteres.");
            

        RuleFor(x => x.TelSetor)
            .MaximumLength(20)
            .WithMessage("O telefone deve ter no máximo 20 caracteres.");
            
    }
}