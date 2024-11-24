using AutoMapper;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.WebApi.Config.Mapping.Action;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class AtividadeProfile : Profile
{
	public AtividadeProfile()
	{
		CreateMap<FormsAtividadeViewModel, Consulta>().AfterMap<ConfigurarMedicoMappingAction>();
		CreateMap<FormsAtividadeViewModel, Cirurgia>().AfterMap<ConfigurarMedicoMappingAction>();

		CreateMap<AtividadeBase, ListarAtividadeViewModel>();
		CreateMap<AtividadeBase, VisualizarAtividadeViewModel>();
	}
}