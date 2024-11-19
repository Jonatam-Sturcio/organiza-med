using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.Compartilhado;

public abstract class AtividadeBase : Entidade
{
	protected AtividadeBase()
	{
	}

	protected AtividadeBase(DateTime data, DateTime horaInicio, DateTime horaTermino)
	{
		Data = data;
		HoraInicio = horaInicio;
		HoraTermino = horaTermino;
		Medicos = [];
	}

	public DateTime Data { get; set; }
	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }

	public abstract TimeSpan ObterPeriodoDescanso();
}