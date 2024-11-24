using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Orm.ModuloMedico;

public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
{
	public RepositorioMedicoOrm(IContextoPersistencia context) : base(context)
	{
	}

	public override Medico SelecionarPorId(Guid id)
	{
		return registros.Include(x => x.Atividades).SingleOrDefault(x => x.Id == id);
	}

	public override async Task<Medico> SelecionarPorIdAsync(Guid id)
	{
		return await registros.Include(x => x.Atividades).SingleOrDefaultAsync(x => x.Id == id);
	}

	public bool CrmExiste(string crm)
	{
		return dbContext.Set<Medico>().Any(m => m.CRM == crm);
	}
}