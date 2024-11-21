using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.Entidades;

public class Cirurgia : AtividadeBase
{
	public Cirurgia(DateTime inicio, DateTime termino, params Medico[] medicos) : base(inicio, termino)
	{
		foreach (var medico in medicos)
		{
			Medicos.Add(medico);
			medico.RegistrarAtividade(this);
		}
	}

	public override TipoAtividadeEnum TipoAtividade
	{
		get => TipoAtividadeEnum.Cirurgia;
		set => tipoAtividade = value;
	}

	public override TimeSpan ObterPeriodoDescanso()
	{
		return new TimeSpan(4, 0, 0);
	}
}