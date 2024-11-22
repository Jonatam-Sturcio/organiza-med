using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Tests.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizaMed.Infra.Tests.ModuloAtividade;

[TestClass]
public class RepositorioCirurgiaEmOrmTests : RepositorioEmOrmTestsBase
{
	[TestMethod]
	public void Deve_inserir_cirurgia_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Cirurgia(dataInicio, dataTermino, medico);

		//action
		repositorioAtividade.Inserir(registro);

		//assert
		var cirurgiaEncontrada = repositorioAtividade.SelecionarPorId(registro.Id);

		Assert.AreEqual(Dominio.Compartilhado.TipoAtividadeEnum.Cirurgia, cirurgiaEncontrada.TipoAtividade);
	}

	[TestMethod]
	public void Deve_editar_cirurgia_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Cirurgia(dataInicio, dataTermino, medico);
		repositorioAtividade.Inserir(registro);

		var registroAtualizado = repositorioAtividade.SelecionarPorId(registro.Id);
		registroAtualizado.HoraTermino = DateTime.Today + new TimeSpan(16, 30, 0);

		//action
		repositorioAtividade.Editar(registroAtualizado);

		//assert
		var cirurgiaEncontrada = repositorioAtividade.SelecionarPorId(registroAtualizado.Id);

		Assert.AreEqual(DateTime.Today + new TimeSpan(16, 30, 0), cirurgiaEncontrada.HoraTermino);
	}

	[TestMethod]
	public void Deve_excluir_cirurgia_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Cirurgia(dataInicio, dataTermino, medico);
		repositorioAtividade.Inserir(registro);

		var registroExcluido = repositorioAtividade.SelecionarPorId(registro.Id);

		//action
		repositorioAtividade.Excluir(registroExcluido);

		//assert
		var cirurgiaEncontrada = repositorioAtividade.SelecionarPorId(registroExcluido.Id);

		Assert.IsNull(cirurgiaEncontrada);
	}

	[TestMethod]
	public void Deve_selecionar_todos_cirurgias_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-CD");
		repositorioMedico.Inserir(medico);
		var medicoBanco = repositorioMedico.SelecionarPorId(medico.Id);

		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);

		//action
		var registro = new Cirurgia(dataInicio, dataTermino, medicoBanco);
		repositorioAtividade.Inserir(registro);

		var registro2 = new Cirurgia(dataInicio, dataTermino, medicoBanco);
		repositorioAtividade.Inserir(registro2);

		//assert
		var cirurgiasEncontradas = repositorioAtividade.SelecionarTodos();

		Assert.AreEqual(2, cirurgiasEncontradas.Count);
	}
}