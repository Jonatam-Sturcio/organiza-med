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

	public List<string> ValidarHorario()
	{
		var erros = new List<string>();

		foreach (var medico in Medicos)
		{
			if (!medico.HorarioAtividadeEstaValido(this) && medico.Atividades.Count > 1)
				erros.Add($"Horário indisponivel.");
		}

		return erros;
	}

	public List<string> ValidarMedicosPorAtividade()
	{
		var erros = new List<string>();

		if (this.tipoAtividade == TipoAtividadeEnum.Consulta && Medicos.Count > 1)
			erros.Add("Não pode haver mais de um médico por consulta");

		return erros;
	}
}