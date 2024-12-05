using OrganizaMed.Dominio.ModuloAutenticacao;
using System.Security.Claims;

namespace OrganizaMed.WebApi.Identity;

public class ApiTenantProvider : ITenantProvider
{
	private readonly IHttpContextAccessor ContextAccessor;

	public ApiTenantProvider(IHttpContextAccessor contextAccessor)
	{
		ContextAccessor = contextAccessor;
	}

	public Guid UsuarioId
	{
		get
		{
			var claimId = ContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

			if (claimId == null)
				return Guid.Empty;

			return Guid.Parse(claimId.Value);
		}
	}
}