using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using OrganizaMed.Aplicacao.ModuloAtividade;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Controllers;

[Route("api/atividades")]
[ApiController]
public class AtividadeController(ServicoAtividade servicoAtividade, IMapper mapeador) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get(TipoAtividadeEnum? tipoAtividade)
	{
		Result<List<AtividadeBase>> resultado;

		if (tipoAtividade != null)
		{
			resultado = await servicoAtividade.Filtrar(a => a.TipoAtividade == tipoAtividade);
		}
		else
			resultado = await servicoAtividade.SelecionarTodosAsync();

		if (resultado.IsFailed)
		{
			return StatusCode(500);
		}

		var viewModel = mapeador.Map<ListarAtividadeViewModel[]>(resultado.Value);
		return Ok(viewModel);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var resultado = await servicoAtividade.SelecionarPorIdAsync(id);

		if (resultado.IsFailed)
		{
			return StatusCode(500);
		}
		else if (resultado.Value is null)
		{
			return NotFound(resultado.Errors);
		}

		var viewModel = mapeador.Map<VisualizarAtividadeViewModel>(resultado.Value);

		return Ok(viewModel);
	}

	[HttpPost]
	public async Task<IActionResult> Post(InserirAtividadeViewModel atividadeVm)
	{
		try
		{
			AtividadeBase atividade = atividadeVm.TipoAtividade switch
			{
				TipoAtividadeEnum.Consulta => mapeador.Map<Consulta>(atividadeVm),
				TipoAtividadeEnum.Cirurgia => mapeador.Map<Cirurgia>(atividadeVm),
				_ => throw new InvalidOperationException("Tipo de atividade desconhecido")
			};

			var resultado = await servicoAtividade.InserirAsync(atividade);

			if (resultado.IsFailed)
			{
				return BadRequest(resultado.Errors);
			}
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

		return Ok(atividadeVm);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(Guid id, EditarAtividadeViewModel atividadeVm)
	{
		var selecaoAtividadeOriginal = await servicoAtividade.SelecionarPorIdAsync(id);

		if (selecaoAtividadeOriginal.IsFailed)
		{
			return NotFound(selecaoAtividadeOriginal.Errors);
		}

		var atividadeEditada = mapeador.Map(atividadeVm, selecaoAtividadeOriginal.Value);

		var resultado = await servicoAtividade.EditarAsync(atividadeEditada);

		if (resultado.IsFailed)
		{
			return BadRequest(resultado.Errors);
		}
		return Ok(resultado.Value);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var resultado = await servicoAtividade.ExcluirAsync(id);

		if (resultado.IsFailed)
		{
			return NotFound(resultado.Errors);
		}

		return Ok();
	}
}