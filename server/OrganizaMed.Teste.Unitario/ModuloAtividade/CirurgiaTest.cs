using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Teste.Unitario.ModuloAtividade;

[TestClass]
public class CirurgiaTest
{
	[TestMethod]
	public void Deve_cadastrar_Cirurgia_Corretamente()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var cirurgia = new Cirurgia(dataInicio, dataTermino, medico);

		var errosValidacao = cirurgia.ValidarPeriodoDescanso();
		// Assert
		Assert.AreEqual(0, errosValidacao.Count);
	}

	[TestMethod]
	public void Deve_cadastrar_Cirurgia_Corretamente_Com_varios_medicos()
	{
		// Arrange
		Medico[] medicos = [
			new Medico("Dr. João", "Cardiologia", "12345-SP"),
			new Medico("Dr. Clovis", "Cardiologia", "12345-SP"),
			new Medico("Dr. Caio", "Cardiologia", "12345-SP")];

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var cirurgia = new Cirurgia(dataInicio, dataTermino, medicos);

		var errosValidacao = cirurgia.ValidarPeriodoDescanso();

		// Assert
		Assert.AreEqual(0, errosValidacao.Count);
	}

	[TestMethod]
	public void Deve_registrar_cirurgia_com_periodo_Descanso_Valido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var cirurgia = new Cirurgia(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(20, 30, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(22, 30, 0);
		var cirurgiaDois = new Cirurgia(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = cirurgiaDois.ValidarPeriodoDescanso();
		// Assert
		Assert.AreEqual(0, errosValidacao.Count);
	}

	[TestMethod]
	public void Nao_deve_registrar_cirurgia_com_periodo_Descanso_Invalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var cirurgia = new Cirurgia(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(18, 10, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(23, 10, 0);
		var cirurgiaDois = new Cirurgia(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = cirurgiaDois.ValidarPeriodoDescanso();
		// Assert
		Assert.AreEqual(1, errosValidacao.Count);
	}
}