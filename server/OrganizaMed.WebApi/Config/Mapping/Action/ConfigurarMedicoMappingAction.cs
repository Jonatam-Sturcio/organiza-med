using AutoMapper;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping.Action;

public class ConfigurarMedicoMappingAction(IRepositorioMedico repositorioMedico) : IMappingAction<FormsAtividadeViewModel, AtividadeBase>
{
	public void Process(FormsAtividadeViewModel source, AtividadeBase destination, ResolutionContext context)
	{
		var idMedico = source.MedicosId;

		//	destination.Medicos = repositorioMedico.SelecionarPorId(idMedico);
	}
}