using Microsoft.EntityFrameworkCore;
using OrganizaMed.Infra.Orm.ModuloMedico;

namespace OrganizaMed.Infra.Orm.Compartilhado;

public class OrganizaMedDbContext : DbContext
{
	public OrganizaMedDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
		base.OnModelCreating(modelBuilder);
	}
}