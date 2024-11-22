using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Orm.ModuloMedico;

public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
{
	private readonly DbContext ctx;

	public RepositorioMedicoOrm(DbContext context) : base(context)
	{
		ctx = context;
	}

	public bool CrmExiste(string crm)
	{
		return ctx.Set<Medico>().Any(m => m.CRM == crm);
	}
}