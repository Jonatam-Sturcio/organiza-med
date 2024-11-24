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
		}).WithMessage("Horário indisponível.");

		RuleFor(x => x.Medicos).NotNull().WithMessage("Ao menos 1 médico deve realizar a atividade.");
		RuleFor(x => x).Must(x =>
		{
			var erros = x.ValidarMedicosPorAtividade();
			return !erros.Any();
		}).WithMessage("Não pode haver mais de um médico por consulta");
	}
}