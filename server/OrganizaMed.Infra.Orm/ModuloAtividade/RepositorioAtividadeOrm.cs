using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Orm.ModuloAtividades;

public class RepositorioAtividadeOrm : RepositorioBase<AtividadeBase>, IRepositorioAtividade
{
	public RepositorioAtividadeOrm(IContextoPersistencia ctx) : base(ctx)
	{
	}

	public override async Task<AtividadeBase> SelecionarPorIdAsync(Guid id)
	{
		return await registros.Include(x => x.Medicos).SingleOrDefaultAsync(x => x.Id == id);
	}

	public new async Task<List<AtividadeBase>> SelecionarTodosAsync()
	{
		return await registros.Include(x => x.Medicos).ToListAsync();
	}

	public async Task<List<AtividadeBase>> Filtrar(Func<AtividadeBase, bool> predicate)
	{
		var atividades = await registros.Include(x => x.Medicos).ToListAsync();

		return atividades.Where(predicate).ToList();
	}
}