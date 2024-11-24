using Microsoft.EntityFrameworkCore;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloMedico;
using OrganizaMed.WebApi.Config.Mapping;
using Serilog;

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

		services.AddDbContext<IContextoPersistencia, OrganizaMedDbContext>(optionsBuilder =>
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

	public static void ConfigureCors(this IServiceCollection services, string politicaCors)
	{
		services.AddCors(options =>
		{
			options.AddPolicy(name: politicaCors, policy =>
			{
				policy
				.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
			});
		});
	}

	public static void ConfigureSerilog(this IServiceCollection services, ILoggingBuilder logging, IConfiguration config)
	{
		Log.Logger = new LoggerConfiguration()
			.Enrich.FromLogContext()
			.Enrich.WithClientIp()
			.Enrich.WithMachineName()
			.Enrich.WithThreadId()
			.WriteTo.Console()
			.WriteTo.NewRelicLogs(
			endpointUrl: "https://log-api.newrelic.com/log/v1",
			applicationName: "note-keeper-api-bit",
			licenseKey: config["SERILOG_LICENSE_KEY"])
			.CreateLogger();

		logging.ClearProviders();

		services.AddLogging(builder => builder.AddSerilog(dispose: true));
	}
}