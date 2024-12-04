using OrganizaMed.Dominio.ModuloAutenticacao;
using Taikandi;

namespace OrganizaMed.Dominio.Compartilhado;

public abstract class Entidade
{
	public Guid Id { get; set; }
	public Guid UsuarioId { get; set; }
	public Usuario? Usuario { get; set; }

	public Entidade()
	{
		Id = SequentialGuid.NewGuid();
	}
}