namespace OrganizaMed.Dominio.Compartilhado;

public interface IRepositorio<T> where T : Entidade
{
	void Inserir(T novoRegistro);

	List<T> SelecionarTodos();

	T SelecionarPorId(Guid id);

	Task<bool> InserirAsync(T novoRegistro);

	void Editar(T registro);

	void Excluir(T registro);

	Task<T> SelecionarPorIdAsync(Guid id);

	Task<List<T>> SelecionarTodosAsync();
}