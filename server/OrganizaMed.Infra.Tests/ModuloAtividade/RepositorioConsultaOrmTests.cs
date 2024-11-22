using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Tests.Compartilhado;

namespace OrganizaMed.Infra.Tests.ModuloAtividade;

[TestClass]
public class RepositorioConsultaOrmTests : RepositorioEmOrmTestsBase
{
	[TestMethod]
	public void Deve_inserir_consulta_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Consulta(dataInicio, dataTermino, medico);

		//action
		repositorioAtividade.Inserir(registro);

		//assert
		var consultaEncontrada = repositorioAtividade.SelecionarPorId(registro.Id);

		Assert.AreEqual(Dominio.Compartilhado.TipoAtividadeEnum.Consulta, consultaEncontrada.TipoAtividade);
	}

	[TestMethod]
	public void Deve_editar_consulta_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Consulta(dataInicio, dataTermino, medico);
		repositorioAtividade.Inserir(registro);

		var registroAtualizado = repositorioAtividade.SelecionarPorId(registro.Id);
		registroAtualizado.HoraTermino = DateTime.Today + new TimeSpan(16, 30, 0);

		//action
		repositorioAtividade.Editar(registroAtualizado);

		//assert
		var consultaEncontrada = repositorioAtividade.SelecionarPorId(registroAtualizado.Id);

		Assert.AreEqual(DateTime.Today + new TimeSpan(16, 30, 0), consultaEncontrada.HoraTermino);
	}

	[TestMethod]
	public void Deve_excluir_consulta_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-cd");
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var registro = new Consulta(dataInicio, dataTermino, medico);
		repositorioAtividade.Inserir(registro);

		var registroExcluido = repositorioAtividade.SelecionarPorId(registro.Id);

		//action
		repositorioAtividade.Excluir(registroExcluido);

		//assert
		var consultaEncontrada = repositorioAtividade.SelecionarPorId(registroExcluido.Id);

		Assert.IsNull(consultaEncontrada);
	}

	[TestMethod]
	public void Deve_selecionar_todos_consultas_com_sucesso()
	{
		//arrange
		Medico medico = new Medico("Cleiton", "cardio", "12345-CD");
		repositorioMedico.Inserir(medico);
		var medicoBanco = repositorioMedico.SelecionarPorId(medico.Id);

		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);

		//action
		var registro = new Consulta(dataInicio, dataTermino, medicoBanco);
		repositorioAtividade.Inserir(registro);

		var registro2 = new Consulta(dataInicio, dataTermino, medicoBanco);
		repositorioAtividade.Inserir(registro2);

		//assert
		var consultasEncontradas = repositorioAtividade.SelecionarTodos();

		Assert.AreEqual(2, consultasEncontradas.Count);
	}
}