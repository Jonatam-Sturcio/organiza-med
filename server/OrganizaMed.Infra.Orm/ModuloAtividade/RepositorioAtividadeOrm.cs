using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Infra.Orm.Compartilhado;

namespace OrganizaMed.Infra.Orm.ModuloAtividades;

public class RepositorioAtividadeOrm : RepositorioBase<AtividadeBase>, IRepositorioAtividade
{
	public RepositorioAtividadeOrm(IContextoPersistencia ctx) : base(ctx)
	{
	}
}