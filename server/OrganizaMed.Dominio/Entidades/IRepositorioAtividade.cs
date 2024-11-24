using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.Entidades;

public interface IRepositorioAtividade : IRepositorio<AtividadeBase>
{
	Task<List<AtividadeBase>> Filtrar(Func<AtividadeBase, bool> predicate);
}