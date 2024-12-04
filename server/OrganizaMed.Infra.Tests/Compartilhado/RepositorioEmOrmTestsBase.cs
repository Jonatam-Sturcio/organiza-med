using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloAtividades;
using OrganizaMed.Infra.Orm.ModuloMedico;
using OrganizaMed.Infra.Tests.ModuloMedico;
using System.Diagnostics;

namespace OrganizaMed.Infra.Tests.Compartilhado;

public abstract class RepositorioEmOrmTestsBase
{
	protected OrganizaMedDbContext dbContext;
	protected RepositorioMedicoOrm repositorioMedico;
	protected RepositorioAtividadeOrm repositorioAtividade;
	protected ITenantProvider tenantProvider;

	[TestInitialize]
	public void Inicializar()
	{
		var config = new ConfigurationBuilder().AddUserSecrets<RepositorioMedicoOrmTests>().Build();

		var options = new DbContextOptionsBuilder<OrganizaMedDbContext>()
			.UseSqlServer(config["SQLSERVER_CONNECTION_STRING"])
			.Options;

		dbContext = new OrganizaMedDbContext(options, tenantProvider);

		Debug.WriteLine("Criando banco de dados");
		dbContext.Database.EnsureDeleted();

		dbContext.Database.Migrate();
		Debug.WriteLine("Banco de dados criado com sucesso");

		dbContext.Set<Medico>().RemoveRange(dbContext.Set<Medico>());
		dbContext.Set<AtividadeBase>().RemoveRange(dbContext.Set<AtividadeBase>());

		repositorioMedico = new(dbContext);
		repositorioAtividade = new(dbContext);
	}
}