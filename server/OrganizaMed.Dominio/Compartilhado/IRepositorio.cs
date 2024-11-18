using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Dominio.Compartilhado;

public interface IRepositorio<T> where T : EntidadeBase<T>
{
	void Inserir(T novoRegistro);

	List<T> SelecionarTodos();

	Task<bool> InserirAsync(T novoRegistro);

	Task<List<Medico>> SelecionarTodosAsync();
}