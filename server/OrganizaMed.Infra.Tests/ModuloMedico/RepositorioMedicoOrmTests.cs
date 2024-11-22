using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Tests.Compartilhado;

namespace OrganizaMed.Infra.Tests.ModuloMedico;

[TestClass]
public class RepositorioMedicoOrmTests : RepositorioEmOrmTestsBase
{
	[TestMethod]
	public void Deve_inserir_medico_com_sucesso()
	{
		//arrange
		Medico registro = new Medico("Cleiton", "cardio", "12345-cd");

		//action
		repositorioMedico.Inserir(registro);

		//assert
		Medico medicoEncontrado = repositorioMedico.SelecionarPorId(registro.Id);

		Assert.AreEqual("Cleiton", medicoEncontrado.Nome);
	}

	[TestMethod]
	public void Deve_editar_medico_com_sucesso()
	{
		//arrange
		Medico registro = new Medico("Cleiton", "cardio", "12345-cd");
		repositorioMedico.Inserir(registro);

		Medico registroAtualizado = repositorioMedico.SelecionarPorId(registro.Id);
		registroAtualizado.Nome = "Cleiton Editado";

		//action
		repositorioMedico.Editar(registroAtualizado);

		//assert
		Medico medicoEncontrado = repositorioMedico.SelecionarPorId(registro.Id);

		Assert.AreEqual("Cleiton Editado", medicoEncontrado.Nome);
	}

	[TestMethod]
	public void Deve_excluir_medico_com_sucesso()
	{
		//arrange
		Medico registro = new Medico("Cleiton", "cardio", "12345-cd");
		repositorioMedico.Inserir(registro);

		Medico registroExcluido = repositorioMedico.SelecionarPorId(registro.Id);

		//action
		repositorioMedico.Excluir(registroExcluido);

		//assert
		Medico medicoEncontrado = repositorioMedico.SelecionarPorId(registroExcluido.Id);

		Assert.IsNull(medicoEncontrado);
	}

	[TestMethod]
	public void Deve_selecionar_todos_medicos_com_sucesso()
	{
		//arrange
		Medico registro = new Medico("Cleiton", "cardio", "12345-cd");
		Medico registro2 = new Medico("Cleiton2", "cardio", "12345-cd");
		Medico registro3 = new Medico("Cleiton3", "cardio", "12345-cd");

		//action
		repositorioMedico.Inserir(registro);
		repositorioMedico.Inserir(registro2);
		repositorioMedico.Inserir(registro3);

		//assert
		var medicosEncontrado = repositorioMedico.SelecionarTodos();

		Assert.AreEqual(3, medicosEncontrado.Count);
	}
}