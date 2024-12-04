﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OrganizaMed.Aplicacao.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Infra.Orm.Compartilhado;
using System.Text;

namespace OrganizaMed.WebApi.Identity;

public static class IdentityDependencyInjection
{
	public static void ConfigureIdentity(this IServiceCollection services)
	{
		services.AddScoped<ServicoAutenticacao>();
		services.AddScoped<JsonWebTokenProvider>();
		services.AddScoped<ITenantProvider, ApiTenantProvider>();

		services.AddIdentity<Usuario, Cargo>(options =>
		{
			options.User.RequireUniqueEmail = true;
		})
			.AddEntityFrameworkStores<OrganizaMedDbContext>()
			.AddDefaultTokenProviders();
	}

	public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
	{
		var chaveGeracaoJwt = config["JWT_GENERATION_KEY"];

		if (chaveGeracaoJwt == null)
			throw new ArgumentException("Não foi possível obter a chave de geração de tokens da aplicação.");

		var chaveEmBytes = Encoding.ASCII.GetBytes(chaveGeracaoJwt);

		var audienciaValida = config["JWT_AUDIENCE_DOMAIN"];

		if (audienciaValida == null)
			throw new ArgumentException("Não foi possível obter a chave de dominio de audiencia.");

		services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(x =>
		{
			x.RequireHttpsMetadata = true;
			x.SaveToken = true;
			x.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(chaveEmBytes),
				ValidAudience = audienciaValida,
				ValidIssuer = "OrganizaMed",
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateLifetime = true
			};
		});
	}
}