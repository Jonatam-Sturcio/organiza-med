using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloMedico;
using System.Diagnostics;

namespace OrganizaMed.Infra.Tests.ModuloMedico;

[TestClass]
public class RepositorioMedicoOrmTests
{
	private readonly OrganizaMedDbContext db;

	public RepositorioMedicoOrmTests()
	{
		var config = new ConfigurationBuilder().AddUserSecrets<RepositorioMedicoOrmTests>().Build();

		var options = new DbContextOptionsBuilder<OrganizaMedDbContext>()
			.UseSqlServer(config["SQLSERVER_CONNECTION_STRING"], options => options.EnableRetryOnFailure())
			.Options;

		db = new OrganizaMedDbContext(options);

		db.Set<Medico>().RemoveRange(db.Set<Medico>());
		db.Set<AtividadeBase>().RemoveRange(db.Set<AtividadeBase>());

		db.SaveChanges();
	}

	[TestInitialize]
	public void Initialize()
	{
		Debug.WriteLine("Criando banco de dados");
		db.Database.EnsureDeleted();

		db.Database.Migrate();
		Debug.WriteLine("Banco de dados criado com sucesso");
	}

	[TestMethod]
	public void Deve_inserir_medico()
	{
		//arrange
		Medico registro = new Medico("Cleiton", "cardio", "12345-cd");

		var repositorio = new RepositorioMedicoOrm(db);

		//action
		repositorio.Inserir(registro);

		//assert
		Medico medicoEncontrado = repositorio.SelecionarPorId(registro.Id);

		Assert.AreEqual("Cleiton", registro.Nome);
	}
}