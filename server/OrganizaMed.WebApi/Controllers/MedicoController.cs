using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;

[Route("api/categorias")]
[ApiController]
public class MedicoController(ServicoMedico servicoMedico, IMapper mapeador) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var resultado = await servicoMedico.SelecionarTodosAsync();

		if (resultado.IsFailed)
		{
			return StatusCode(500);
		}

		var viewModel = mapeador.Map<ListarMedicoViewModel[]>(resultado.Value);

		return Ok(viewModel);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var resultado = await servicoMedico.SelecionarPorIdAsync(id);

		if (resultado.IsFailed)
		{
			return StatusCode(500);
		}
		else if (resultado.Value is null)
		{
			return NotFound(resultado.Errors);
		}

		var viewModel = mapeador.Map<VisualizarMedicoViewModel>(resultado.Value);

		return Ok(viewModel);
	}

	[HttpPost]
	public async Task<IActionResult> Post(InserirMedicoViewModel categoriaVm)
	{
		var categoria = mapeador.Map<Medico>(categoriaVm);

		var resultado = await servicoMedico.InserirAsync(categoria);

		if (resultado.IsFailed)
		{
			return BadRequest(resultado.Errors);
		}

		return Ok(categoriaVm);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(Guid id, EditarMedicoViewModel categoriaVm)
	{
		var selecaoMedicoOriginal = await servicoMedico.SelecionarPorIdAsync(id);

		if (selecaoMedicoOriginal.IsFailed)
		{
			return NotFound(selecaoMedicoOriginal.Errors);
		}

		var categoriaEditada = mapeador.Map(categoriaVm, selecaoMedicoOriginal.Value);

		var resultado = await servicoMedico.EditarAsync(categoriaEditada);

		if (resultado.IsFailed)
		{
			return BadRequest(resultado.Errors);
		}

		return Ok(resultado.Value);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var resultado = await servicoMedico.ExcluirAsync(id);

		if (resultado.IsFailed)
		{
			return NotFound(resultado.Errors);
		}

		return Ok();
	}
}