using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.Compartilhado;

public abstract class AtividadeBase : Entidade
{
	public AtividadeBase()
	{
	}

	public AtividadeBase(DateTime horaInicio, DateTime horaTermino)
	{
		HoraInicio = horaInicio;
		HoraTermino = horaTermino;
		Medicos = [];
	}

	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }
	public abstract TipoAtividadeEnum TipoAtividade { get; set; }
	protected TipoAtividadeEnum tipoAtividade;

	public abstract TimeSpan ObterPeriodoDescanso();

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