using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.ModuloAtividade;

public class Consulta : AtividadeBase
{
	public Consulta(DateTime data, DateTime inicio, DateTime termino, Medico medico) : base(data, inicio, termino)
	{
		Medicos.Add(medico);
	}

	public TipoAtividadeEnum TipoAtividade { get; set; }

	public override TimeSpan ObterPeriodoDescanso()
	{
		return new TimeSpan(0, 10, 0);
	}

	public List<string> ValidarPeriodoDescanso()
	{
		var erros = new List<string>();

		foreach (var medico in Medicos)
		{
			if (!medico.PeriodoDeDescansoEstaValido(this))
				erros.Add($"O médico '{medico.Nome}' está em periodo de descanso mandatório.");
		}

		return erros;
	}
}