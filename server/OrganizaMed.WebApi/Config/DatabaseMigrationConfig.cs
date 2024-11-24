using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.WebApi.Config;

public static class DatabaseMigrationConfig
{
	public static bool AutoMigrateDatabase(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();

		var dbcontext = scope.ServiceProvider.GetRequiredService<IContextoPersistencia>();

		bool migracaoConcluida = false;

		if (dbcontext is OrganizaMedDbContext organizaMedDbContext)
		{
			migracaoConcluida = MigradorBancoDados.AtualizarBancoDados(organizaMedDbContext);
		}

		return migracaoConcluida;
	}
}