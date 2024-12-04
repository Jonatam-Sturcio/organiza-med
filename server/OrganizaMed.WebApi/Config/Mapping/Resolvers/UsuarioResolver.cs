namespace OrganizaMed.WebApi.Config.Mapping.Resolvers;

using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

public class UsuarioResolver : IValueResolver<Object, Object, Guid>
{
	private readonly IHttpContextAccessor contextAccessor;

	public UsuarioResolver(IHttpContextAccessor contextAccessor)
	{
		this.contextAccessor = contextAccessor;
	}

	public Guid Resolve(Object viewModel, Object entidade, Guid id, ResolutionContext context)
	{
		var consultaUsuario = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

		if (consultaUsuario == null) throw new AuthenticationFailureException($"Não foi possívelobter a claim de autenticação do usuário ID: {id}");
		return Guid.Parse(consultaUsuario.Value);
	}
}