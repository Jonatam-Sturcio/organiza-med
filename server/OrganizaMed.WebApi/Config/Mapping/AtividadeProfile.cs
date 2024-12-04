using AutoMapper;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.WebApi.Config.Mapping.Action;
using OrganizaMed.WebApi.Config.Mapping.Resolvers;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class AtividadeProfile : Profile
{
	public AtividadeProfile()
	{
		CreateMap<FormsAtividadeViewModel, Consulta>()
			.ForMember(dest => dest.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
			.AfterMap<ConfigurarMedicoMappingAction>();

		CreateMap<FormsAtividadeViewModel, Cirurgia>()
			.ForMember(dest => dest.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
			.AfterMap<ConfigurarMedicoMappingAction>();

		CreateMap<AtividadeBase, ListarAtividadeViewModel>();
		CreateMap<AtividadeBase, VisualizarAtividadeViewModel>();
	}
}