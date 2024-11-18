using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Infra.Orm.Compartilhado;

public class RepositorioBase<TEntidade> where TEntidade : Entidade
{
	protected OrganizaMedDbContext dbContext;
	protected DbSet<TEntidade> registros;

	public RepositorioBase(DbContext ctx)
	{
		this.dbContext = (OrganizaMedDbContext)ctx;
		this.registros = dbContext.Set<TEntidade>();
	}

	public virtual void Inserir(TEntidade novoRegistro)
	{
		registros.Add(novoRegistro);
		dbContext.SaveChanges();
	}

	public virtual TEntidade SelecionarPorId(Guid id)
	{
		return registros.SingleOrDefault(x => x.Id == id);
	}

	public virtual List<TEntidade> SelecionarTodos()
	{
		return registros.ToList();
	}

	public async Task<bool> InserirAsync(TEntidade registro)
	{
		await registros.AddAsync(registro);
		await dbContext.SaveChangesAsync();
		return true;
	}

	public virtual async Task<TEntidade> SelecionarPorIdAsync(Guid id)
	{
		return await registros.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task<List<TEntidade>> SelecionarTodosAsync()
	{
		return await registros.ToListAsync();
	}
}