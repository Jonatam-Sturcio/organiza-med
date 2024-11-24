using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloAtividades;
using OrganizaMed.Infra.Orm.ModuloMedico;

namespace OrganizaMed.Infra.Orm.Compartilhado;

public class OrganizaMedDbContext : DbContext, IContextoPersistencia
{
	public OrganizaMedDbContext(DbContextOptions options) : base(options)
	{
	}

	public async Task<bool> GravarAsync()
	{
		await SaveChangesAsync();
		return true;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
		modelBuilder.ApplyConfiguration(new MapeadorAtividadeOrm());
		base.OnModelCreating(modelBuilder);
	}
}