using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrganizaMed.Aplicacao.ModuloAtividade;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Orm.Compartilhado;
using OrganizaMed.Infra.Orm.ModuloAtividades;
using OrganizaMed.Infra.Orm.ModuloMedico;
using OrganizaMed.WebApi.Config.Mapping;
using OrganizaMed.WebApi.Config.Mapping.Action;
using OrganizaMed.WebApi.Config.Mapping.Resolvers;
using OrganizaMed.WebApi.Filters;
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

		services.AddScoped<IRepositorioAtividade, RepositorioAtividadeOrm>();
		services.AddScoped<ServicoAtividade>();
	}

	public static void ConfigureAutoMapper(this IServiceCollection services)
	{
		services.AddScoped<UsuarioResolver>();
		services.AddScoped<ConfigurarMedicoMappingAction>();
		services.AddAutoMapper(config =>
		{
			config.AddProfile<MedicoProfile>();
			config.AddProfile<AtividadeProfile>();
			config.AddProfile<UsuarioProfile>();
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

	public static void ConfigureControllersWithFilters(this IServiceCollection services)
	{
		services.AddControllers(options =>
		{
			options.Filters.Add<ResponseWrapperFilter>();
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

	public static void ConfigureSwaggerAuthorization(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();

		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrganizaMed.Webapi", Version = "v1" });

			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Description = "Por favor informe o token no padrão {Bearer token}",
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey,
				BearerFormat = "JWT",
				Scheme = "Bearer"
			});

			c.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type=ReferenceType.SecurityScheme,
							Id="Bearer"
						}
					},
					new string[]{}
				}
			});
		});
	}
}