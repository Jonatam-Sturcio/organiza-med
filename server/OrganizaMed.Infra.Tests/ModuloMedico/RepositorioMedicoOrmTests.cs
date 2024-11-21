using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Tests.ModuloMedico;

[TestClass]
public class RepositorioMedicoOrmTests
{
	private readonly OrganizaMedDbContext db;

	public RepositorioMedicoOrmTests()
	{
		var builder = new DbContextOptionsBuilder<OrganizaMedDbContext>();
		IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<RepositorioMedicoOrmTests>().Build();

		builder.UseSqlServer(config["SQL_CONNECTION_STRING"]);

		db = new OrganizaMedDbContext(builder.Options);

		db.Set<Medico>().RemoveRange(db.Set<Medico>());
		db.Set<AtividadeBase>().RemoveRange(db.Set<AtividadeBase>());

		db.SaveChanges();
	}
}