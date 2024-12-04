using FluentResults;
using Microsoft.AspNetCore.Identity;
using OrganizaMed.Dominio.ModuloAutenticacao;

namespace OrganizaMed.Aplicacao.ModuloAutenticacao;

public class ServicoAutenticacao
{
	private readonly UserManager<Usuario> UserManager;
	private readonly SignInManager<Usuario> SignInManager;

	public ServicoAutenticacao(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
	{
		UserManager = userManager;
		SignInManager = signInManager;
	}

	public async Task<Result<Usuario>> RegistrarAsync(Usuario usuario, string senha)
	{
		var usuarioResult = await UserManager.CreateAsync(usuario, senha);

		if (!usuarioResult.Succeeded)
		{
			return Result.Fail(usuarioResult.Errors.Select(failure => new Error(failure.Description)));
		}

		return Result.Ok(usuario);
	}

	public async Task<Result<Usuario>> Autenticar(string login, string senha)
	{
		var loginResult = await SignInManager.PasswordSignInAsync(login, senha, false, true);

		var erros = new List<IError>();

		if (loginResult.IsLockedOut)
			erros.Add(new Error("O acesso para este usuário foi bloqueado"));

		if (loginResult.IsNotAllowed)
			erros.Add(new Error("O acesso para este usuário não é permitido"));

		if (!loginResult.Succeeded)
			erros.Add(new Error("O login ou a senha estão incorretas"));

		if (erros.Count > 0)
			return Result.Fail(erros);

		var usuario = await UserManager.FindByNameAsync(login);

		if (usuario == null)
			return Result.Fail("Não foi possível encontrar o usuário");

		return Result.Ok(usuario);
	}

	public async Task<Result> Sair()
	{
		await SignInManager.SignOutAsync();
		return Result.Ok();
	}
}