using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public interface IRepositorioMedico : IRepositorio<Medico>
{
	Task<List<Medico>> OrdenarMedicosComMaisAtividades();

	public abstract bool CrmExiste(string nome);
}