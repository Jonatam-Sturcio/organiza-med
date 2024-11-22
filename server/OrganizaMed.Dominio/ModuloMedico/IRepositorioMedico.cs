using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public interface IRepositorioMedico : IRepositorio<Medico>
{
	public abstract bool CrmExiste(string nome);
}