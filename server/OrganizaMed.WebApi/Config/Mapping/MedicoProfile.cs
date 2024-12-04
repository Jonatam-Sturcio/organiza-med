using AutoMapper;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.Config.Mapping.Resolvers;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class MedicoProfile : Profile
{
	public MedicoProfile()
	{
		CreateMap<InserirMedicoViewModel, Medico>()
			.ForMember(dest => dest.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());
		CreateMap<EditarMedicoViewModel, Medico>()
			.ForMember(dest => dest.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

		CreateMap<Medico, ListarMedicoViewModel>();
		CreateMap<Medico, VisualizarMedicoViewModel>();
	}
}