using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.Entidades;

public class Cirurgia : AtividadeBase
{
	public TipoAtividadeEnum TipoAtividade { get; set; }

	public override TimeSpan ObterPeriodoDescanso()
	{
		return new TimeSpan(4, 0, 0);
	}
}