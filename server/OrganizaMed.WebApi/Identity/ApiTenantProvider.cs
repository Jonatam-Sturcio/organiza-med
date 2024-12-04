using OrganizaMed.Dominio.ModuloAutenticacao;
using System.Security.Claims;

namespace OrganizaMed.WebApi.Identity;

public class ApiTenantProvider : ITenantProvider
{
	public ApiTenantProvider(IHttpContextAccessor contextAccessor)
	{
		ContextAccessor = contextAccessor;
	}

	public Guid? UsuarioId
	{
		get
		{
			var claimId = ContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

			if (claimId == null)
				return null;

			return Guid.Parse(claimId.Value);
		}
	}

	public IHttpContextAccessor ContextAccessor { get; }
}