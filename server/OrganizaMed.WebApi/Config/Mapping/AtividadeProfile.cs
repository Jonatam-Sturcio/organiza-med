using AutoMapper;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class AtividadeProfile : Profile
{
	public AtividadeProfile()
	{
		CreateMap<InserirAtividadeViewModel, AtividadeBase>();
		CreateMap<EditarAtividadeViewModel, AtividadeBase>();

		CreateMap<AtividadeBase, ListarAtividadeViewModel>();
		CreateMap<AtividadeBase, VisualizarAtividadeViewModel>();
	}
}