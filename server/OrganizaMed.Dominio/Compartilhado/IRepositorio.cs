namespace OrganizaMed.Dominio.Compartilhado;

public interface IRepositorio<T> where T : Entidade
{
	void Inserir(T novoRegistro);

	List<T> SelecionarTodos();

	Task<bool> InserirAsync(T novoRegistro);

	Task<List<T>> SelecionarTodosAsync();
}