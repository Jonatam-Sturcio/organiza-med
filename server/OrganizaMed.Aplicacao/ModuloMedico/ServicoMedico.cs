using FluentResults;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Aplicacao.ModuloMedico;

public class ServicoMedico
{
	private readonly IRepositorioMedico repositorioMedico;

	public ServicoMedico(IRepositorioMedico repositorioMedico)
	{
		this.repositorioMedico = repositorioMedico;
	}

	public async Task<Result<Medico>> InserirAsync(Medico medico)
	{
		var validador = new ValidadorMedico(repositorioMedico);

		var resultado = await validador.ValidateAsync(medico);

		if (!resultado.IsValid)
		{
			var erros = resultado.Errors.Select(err => err.ErrorMessage);

			return Result.Fail(erros);
		}

		await repositorioMedico.InserirAsync(medico);

		return Result.Ok(medico);
	}

	public async Task<Result<Medico>> EditarAsync(Medico medico)
	{
		var validador = new ValidadorMedico(repositorioMedico);

		var resultado = await validador.ValidateAsync(medico);

		if (!resultado.IsValid)
		{
			var erros = resultado.Errors.Select(err => err.ErrorMessage);

			return Result.Fail(erros);
		}
		repositorioMedico.Editar(medico);

		return Result.Ok(medico);
	}

	public async Task<Result<Medico>> ExcluirAsync(Guid id)
	{
		var medico = await repositorioMedico.SelecionarPorIdAsync(id);

		repositorioMedico.Excluir(medico);

		return Result.Ok();
	}

	public async Task<Result<Medico>> SelecionarPorIdAsync(Guid id)
	{
		var categoria = await repositorioMedico.SelecionarPorIdAsync(id);

		return Result.Ok(categoria);
	}

	public async Task<Result<List<Medico>>> SelecionarTodosAsync()
	{
		var medico = await repositorioMedico.SelecionarTodosAsync();

		return Result.Ok(medico);
	}
}