using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloAutenticacao;
using OrganizaMed.Dominio.ModuloAutenticacao;
using OrganizaMed.WebApi.Identity;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
	private readonly ServicoAutenticacao servicoAutenticacao;
	private readonly IMapper mapeador;
	private readonly JsonWebTokenProvider geradorTokens;

	public AutenticacaoController(JsonWebTokenProvider geradorTokens, ServicoAutenticacao ServicoAutenticacao, IMapper Mapeador)
	{
		servicoAutenticacao = ServicoAutenticacao;
		mapeador = Mapeador;
		this.geradorTokens = geradorTokens;
	}

	[HttpPost("registrar")]
	public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel viewModel)
	{
		var usuario = mapeador.Map<Usuario>(viewModel);

		var usuarioResult = await servicoAutenticacao.RegistrarAsync(usuario, viewModel.Password);

		if (usuarioResult.IsFailed)
			return BadRequest(usuarioResult.Errors);

		var tokenViewModel = geradorTokens.GerarTokenAcesso(usuario);

		return Ok(tokenViewModel);
	}

	[HttpPost("autenticar")]
	public async Task<IActionResult> Autenticar(AutenticarUsuarioViewModel viewModel)
	{
		var usuarioResult = await servicoAutenticacao.Autenticar(viewModel.UserName, viewModel.Password);

		if (usuarioResult.IsFailed)
			return BadRequest(usuarioResult.Errors);

		var usuario = usuarioResult.Value;

		var tokenViewModel = geradorTokens.GerarTokenAcesso(usuario);

		return Ok(tokenViewModel);
	}

	[HttpPost("sair")]
	[Authorize]
	public async Task<IActionResult> Sair()
	{
		await servicoAutenticacao.Sair();
		return Ok();
	}
}