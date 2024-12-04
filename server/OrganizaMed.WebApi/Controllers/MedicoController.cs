using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloMedico;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;

[Route("api/medicos")]
[ApiController]
[Authorize]
public class MedicoController(ServicoMedico servicoMedico, IMapper mapeador) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get(bool? maisAtividades)
	{
		Result<List<Medico>> resultado;

		if (maisAtividades != null && maisAtividades == true)
		{
			resultado = await servicoMedico.FiltrarPorMedicosComMaisAtividades();
		}
		else
		{
			resultado = await servicoMedico.SelecionarTodosAsync();
		}

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
	public async Task<IActionResult> Post(InserirMedicoViewModel medicoVm)
	{
		var medico = mapeador.Map<Medico>(medicoVm);

		var resultado = await servicoMedico.InserirAsync(medico);

		if (resultado.IsFailed)
		{
			return BadRequest(resultado.Errors);
		}

		var resultadoMedico = mapeador.Map<ListarMedicoViewModel>(medico);

		return Ok(resultadoMedico);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(Guid id, EditarMedicoViewModel medicoVm)
	{
		var selecaoMedicoOriginal = await servicoMedico.SelecionarPorIdAsync(id);

		if (selecaoMedicoOriginal.IsFailed)
		{
			return NotFound(selecaoMedicoOriginal.Errors);
		}

		var medicoEditada = mapeador.Map(medicoVm, selecaoMedicoOriginal.Value);

		var resultado = await servicoMedico.EditarAsync(medicoEditada);

		if (resultado.IsFailed)
		{
			return BadRequest(resultado.Errors);
		}

		var resultadoMedico = mapeador.Map<ListarMedicoViewModel>(medicoEditada);

		return Ok(resultadoMedico);
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