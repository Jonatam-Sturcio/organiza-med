using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Teste.Unitario.ModuloAtividade;

[TestClass]
public class ConsultaTest
{
	[TestMethod]
	public void Deve_cadastrar_Consulta_Corretamente()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var consulta = new Consulta(dataInicio, dataTermino, medico);

		var errosValidacao = consulta.ValidarHorario();
		// Assert
		Assert.AreEqual(0, errosValidacao.Count);
	}

	[TestMethod]
	public void Deve_registrar_consulta_com_periodo_Descanso_Valido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var consulta = new Consulta(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(16, 30, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(18, 30, 0);
		var consultaDois = new Consulta(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = consultaDois.ValidarHorario();
		// Assert
		Assert.AreEqual(0, errosValidacao.Count);
	}

	[TestMethod]
	public void Nao_deve_registrar_consulta_com_periodo_Descanso_Invalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var consulta = new Consulta(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(16, 10, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(18, 10, 0);
		var consultaDois = new Consulta(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = consultaDois.ValidarHorario();
		// Assert
		Assert.AreEqual(1, errosValidacao.Count);
	}

	[TestMethod]
	public void Deve_Retornar_erro_Cadastrando_Com_Conflito_Horario()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var consulta = new Consulta(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(15, 0, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(16, 0, 0);
		var consultaDois = new Consulta(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = consultaDois.ValidarHorario();
		// Assert
		Assert.AreEqual(1, errosValidacao.Count);
	}
}