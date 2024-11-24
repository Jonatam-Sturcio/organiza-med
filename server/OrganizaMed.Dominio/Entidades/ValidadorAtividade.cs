using FluentValidation;
using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.Entidades;

public class ValidadorAtividade : AbstractValidator<AtividadeBase>
{
	public ValidadorAtividade()
	{
		RuleFor(x => x).Must(x =>
		{
			var erros = x.ValidarHorario();
			return !erros.Any();
		})
		.WithMessage("Horário indisponível.");
	}
}