using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Orm.ModuloMedico;

public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
{
	public RepositorioMedicoOrm(DbContext context) : base(context)
	{
	}
}