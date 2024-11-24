using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.WebApi.ViewModels;

public class FormsAtividadeViewModel
{
	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<Guid> MedicosId { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}

public class InserirAtividadeViewModel : FormsAtividadeViewModel
{
}

public class EditarAtividadeViewModel : FormsAtividadeViewModel
{
}

public class ListarAtividadeViewModel
{
	public Guid Id { get; set; }

	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<ListarMedicoViewModel> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}

public class VisualizarAtividadeViewModel
{
	public Guid Id { get; set; }

	public DateTime HoraInicio { get; set; }
	public DateTime HoraTermino { get; set; }
	public List<ListarMedicoViewModel> Medicos { get; set; }
	public TipoAtividadeEnum TipoAtividade { get; set; }
}