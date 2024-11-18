using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public class Medico : EntidadeBase<Medico>
{
	public Medico()
	{
	}

	public Medico(string nome, string especialidade, string Crm)
	{
		Nome = nome;
		Especialidade = especialidade;
		CRM = Crm;
	}

	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }

	public override void Atualizar(Medico registro)
	{
		Id = registro.Id;
		Nome = registro.Nome;
		CRM = registro.CRM;
	}

	public override string ToString()
	{
		return $"Nome: {Nome} | CRM: {CRM}";
	}
}