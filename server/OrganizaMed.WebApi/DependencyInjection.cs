using Microsoft.EntityFrameworkCore;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloMedico;
using OrganizaMed.WebApi.Config.Mapping;

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

	public static void ConfigureCoreServices(this IServiceCollection services)
	{
		services.AddScoped<IRepositorioMedico, RepositorioMedicoOrm>();
		services.AddScoped<ServicoMedico>();
	}

	public static void ConfigureAutoMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(config =>
		{
			config.AddProfile<MedicoProfile>();
		});
	}
}