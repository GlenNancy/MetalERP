using FluentValidation;

namespace MetalERP.Application.Features.Setores.CreateSetor;

public class CreateSetorValidator
    : AbstractValidator<CreateSetorCommand>
{
    public CreateSetorValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.TelSetor)
            .MaximumLength(20);
    }
}