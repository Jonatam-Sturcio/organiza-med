using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.WebApi.ViewModels;

public class InserirMedicoViewModel
{
	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }
}

public class EditarMedicoViewModel
{
	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }
}

public class ListarMedicoViewModel
{
	public Guid Id { get; set; }

	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }
}

public class VisualizarMedicoViewModel
{
	public Guid Id { get; set; }

	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }

	public List<AtividadeBase> Atividades { get; set; }
}