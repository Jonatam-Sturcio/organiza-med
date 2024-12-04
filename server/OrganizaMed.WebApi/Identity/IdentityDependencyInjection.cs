using Microsoft.AspNetCore.Identity;
using OrganizaMed.Aplicacao.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.WebApi.Identity;

public static class IdentityDependencyInjection
{
	public static void ConfigureIdentity(this IServiceCollection services)
	{
		services.AddScoped<ServicoAutenticacao>();

		services.AddScoped<ITenantProvider, ApiTenantProvider>();

		services.AddIdentity<Usuario, Cargo>(options =>
		{
			options.User.RequireUniqueEmail = true;
		})
			.AddEntityFrameworkStores<OrganizaMedDbContext>()
			.AddDefaultTokenProviders();
	}
}