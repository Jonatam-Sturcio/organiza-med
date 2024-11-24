using FluentResults;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;

namespace OrganizaMed.Aplicacao.ModuloAtividade;

public class ServicoAtividade
{
	private readonly IRepositorioAtividade repositorioAtividade;

	public ServicoAtividade(IRepositorioAtividade repositorioAtividadeBase)
	{
		this.repositorioAtividade = repositorioAtividadeBase;
	}

	public async Task<Result<AtividadeBase>> InserirAsync(AtividadeBase atividade)
	{
		var validador = new ValidadorAtividade();

		var resultado = await validador.ValidateAsync(atividade);

		if (!resultado.IsValid)
		{
			var erros = resultado.Errors.Select(err => err.ErrorMessage);

			return Result.Fail(erros);
		}

		await repositorioAtividade.InserirAsync(atividade);

		return Result.Ok(atividade);
	}

	public async Task<Result<AtividadeBase>> EditarAsync(AtividadeBase atividade)
	{
		var validador = new ValidadorAtividade();

		var resultado = await validador.ValidateAsync(atividade);

		if (!resultado.IsValid)
		{
			var erros = resultado.Errors.Select(err => err.ErrorMessage);

			return Result.Fail(erros);
		}
		repositorioAtividade.Editar(atividade);

		return Result.Ok(atividade);
	}

	public async Task<Result<AtividadeBase>> ExcluirAsync(Guid id)
	{
		var atividade = await repositorioAtividade.SelecionarPorIdAsync(id);

		repositorioAtividade.Excluir(atividade);

		return Result.Ok();
	}

	public async Task<Result<AtividadeBase>> SelecionarPorIdAsync(Guid id)
	{
		var categoria = await repositorioAtividade.SelecionarPorIdAsync(id);

		return Result.Ok(categoria);
	}

	public async Task<Result<List<AtividadeBase>>> SelecionarTodosAsync()
	{
		var atividade = await repositorioAtividade.SelecionarTodosAsync();

		return Result.Ok(atividade);
	}
}