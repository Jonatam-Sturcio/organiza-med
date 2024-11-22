using FluentResults;
using OrganizaMed.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		var validador = new ValidadorMedico();

		var resultado = await validador.ValidateAsync(medico);

		if (!resultado.IsValid)
		{
			var erros = resultado.Errors.Select(err => err.ErrorMessage);

			return Result.Fail(erros);
		}

		await repositorioMedico.InserirAsync(medico);

		return Result.Ok(medico);
	}
}