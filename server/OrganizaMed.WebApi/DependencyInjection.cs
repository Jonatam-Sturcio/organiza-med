using Microsoft.EntityFrameworkCore;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.WebApi;

public static class DependencyInjection
{
	public static void ConfigureDbContext(
	this IServiceCollection services,
	IConfiguration config,
	IWebHostEnvironment environment
)
	{
		var connectionString = config["SQLSERVER_CONNECTION_STRING"];

		if (connectionString == null)
			throw new ArgumentNullException("'SQLSERVER_CONNECTION_STRING' não foi fornecida para o ambiente.");

		services.AddDbContext<OrganizaMedDbContext>(optionsBuilder =>
		{
			if (!environment.IsDevelopment())
				optionsBuilder.EnableSensitiveDataLogging(false);

			optionsBuilder.UseSqlServer(connectionString, dbOptions =>
			{
				dbOptions.EnableRetryOnFailure();
			});
		});
	}
}