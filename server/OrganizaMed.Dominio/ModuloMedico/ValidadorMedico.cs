using FluentValidation;

namespace OrganizaMed.Dominio.ModuloMedico;

public class ValidadorMedico : AbstractValidator<Medico>
{
	private readonly IRepositorioMedico repositorioMedico;

	public ValidadorMedico(IRepositorioMedico repoMedico)
	{
		repositorioMedico = repoMedico;

		RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório");
		RuleFor(x => x.Especialidade).NotEmpty().WithMessage("A especialidade é obrigatória")
			.MustAsync(async (crm, cancel) => !await Task.Run(() => repositorioMedico.CrmExiste(crm))).WithMessage("Este CRM já está registrado.");
		RuleFor(x => x.CRM).NotEmpty().Matches(@"^\d{5}-[A-Z]{2}$");
	}
}