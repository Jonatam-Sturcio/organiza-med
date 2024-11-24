namespace OrganizaMed.Dominio.Compartilhado;

public interface IContextoPersistencia
{
	Task<bool> GravarAsync();
}