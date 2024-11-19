using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.ModuloAtividade;

public class Consulta : AtividadeBase
{
	public Consulta(DateTime inicio, DateTime termino, Medico medico) : base(inicio, termino)
	{
		Medicos.Add(medico);
		medico.RegistrarAtividade(this);
	}

	public override TipoAtividadeEnum TipoAtividade
	{
		get => TipoAtividadeEnum.Consulta;
		set => tipoAtividade = value;
	}

	public override TimeSpan ObterPeriodoDescanso()
	{
		return new TimeSpan(0, 10, 0);
	}
}