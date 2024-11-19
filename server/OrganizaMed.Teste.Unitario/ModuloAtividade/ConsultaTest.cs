using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Teste.Unitario.ModuloAtividade;

[TestClass]
public class ConsultaTest
{
	[TestMethod]
	public void Nao_deve_registrar_consulta_com_periodo_Descanso_Invalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		var data = DateTime.Today;
		var dataInicio = DateTime.Today + new TimeSpan(14, 0, 0);
		var dataTermino = DateTime.Today + new TimeSpan(16, 0, 0);
		var consulta = new Consulta(dataInicio, dataTermino, medico);

		var dataInicioDois = DateTime.Today + new TimeSpan(16, 10, 0);
		var dataTerminoDois = DateTime.Today + new TimeSpan(18, 10, 0);
		var consultaDois = new Consulta(dataInicioDois, dataTerminoDois, medico);

		var errosValidacao = consultaDois.ValidarPeriodoDescanso();
		// Assert
		Assert.AreEqual(1, errosValidacao.Count);
	}
}