using FluentValidation.Results;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Teste.Unitario.ModuloMedico;

[TestClass]
public class MedicoTest
{
	private ValidadorMedico validador;

	public MedicoTest()
	{
		validador = new ValidadorMedico();
	}

	[TestMethod]
	public void Medico_ComNomeEspecialidadeCrmValidos_DeveSerValido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "12345-SP");

		// Act
		ValidationResult result = validador.Validate(medico);

		// Assert
		Assert.IsTrue(result.IsValid, result.ToString());
	}

	[TestMethod]
	public void Medico_SemNome_DeveSerInvalido()
	{
		// Arrange
		var medico = new Medico("", "Cardiologia", "12345-SP");

		// Act
		ValidationResult result = validador.Validate(medico);

		// Assert
		Assert.IsFalse(result.IsValid, result.ToString());
		Assert.AreEqual("O nome é obrigatório", result.Errors[0].ErrorMessage);
	}

	[TestMethod]
	public void Medico_SemEspecialidade_DeveSerInvalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "", "12345-SP");

		// Act
		ValidationResult result = validador.Validate(medico);

		// Assert
		Assert.IsFalse(result.IsValid, result.ToString());
		Assert.AreEqual("A especialidade é obrigatória", result.Errors[0].ErrorMessage);
	}

	[TestMethod]
	public void Medico_ComCrmInvalido_DeveSerInvalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "1234-SP");

		// Act
		ValidationResult result = validador.Validate(medico);

		// Assert
		Assert.IsFalse(result.IsValid, result.ToString());
	}

	[TestMethod]
	public void Medico_SemCrm_DeveSerInvalido()
	{
		// Arrange
		var medico = new Medico("Dr. João", "Cardiologia", "");

		// Act
		ValidationResult result = validador.Validate(medico);

		// Assert
		Assert.IsFalse(result.IsValid, result.ToString());
	}
}