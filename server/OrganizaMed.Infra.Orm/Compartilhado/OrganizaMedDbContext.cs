using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.ModuloAtividades;
using OrganizaMed.Infra.Orm.ModuloMedico;

namespace OrganizaMed.Infra.Orm.Compartilhado;

public class OrganizaMedDbContext : IdentityDbContext<Usuario, Cargo, Guid>, IContextoPersistencia
{
	private Guid usuarioId;

	public OrganizaMedDbContext(DbContextOptions options, ITenantProvider tenantProvider) : base(options)
	{
		if (tenantProvider != null)
			usuarioId = tenantProvider.UsuarioId;
	}

	public async Task<bool> GravarAsync()
	{
		await SaveChangesAsync();
		return true;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
		modelBuilder.Entity<Medico>().HasQueryFilter(c => c.UsuarioId == usuarioId);

		modelBuilder.ApplyConfiguration(new MapeadorAtividadeOrm());
		modelBuilder.Entity<AtividadeBase>().HasQueryFilter(c => c.UsuarioId == usuarioId);
		base.OnModelCreating(modelBuilder);
	}
}