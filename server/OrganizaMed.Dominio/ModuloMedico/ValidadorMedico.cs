using FluentValidation;

namespace OrganizaMed.Dominio.ModuloMedico;

public class ValidadorMedico : AbstractValidator<Medico>
{
	public ValidadorMedico()
	{
		RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório");
		RuleFor(x => x.Especialidade).NotEmpty().WithMessage("A especialidade é obrigatória");
		RuleFor(x => x.CRM).NotEmpty().Matches(@"^\d{5}-[A-Z]{2}$");
	}
}