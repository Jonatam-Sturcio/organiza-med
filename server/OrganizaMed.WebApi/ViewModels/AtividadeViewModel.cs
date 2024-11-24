using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.WebApi.ViewModels;

public class InserirAtividadeViewModel
{
	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}

public class EditarAtividadeViewModel
{
	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}

public class ListarAtividadeViewModel
{
	public Guid Id { get; set; }

	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}

public class VisualizarAtividadeViewModel
{
	public Guid Id { get; set; }

	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Medico> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}