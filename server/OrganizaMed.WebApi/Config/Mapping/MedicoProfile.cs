using AutoMapper;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping;

public class MedicoProfile : Profile
{
	public MedicoProfile()
	{
		CreateMap<InserirMedicoViewModel, Medico>();
		CreateMap<EditarMedicoViewModel, Medico>();

		CreateMap<Medico, ListarMedicoViewModel>();
		CreateMap<Medico, VisualizarMedicoViewModel>();
	}
}