using AutoMapper;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;
using OrganizaMed.WebApi.ViewModels;

namespace OrganizaMed.WebApi.Config.Mapping.Resolver;

public class AtividadeBaseResolver : ITypeConverter<InserirAtividadeViewModel, AtividadeBase>
{
	public AtividadeBase Convert(InserirAtividadeViewModel source, AtividadeBase destination, ResolutionContext context)
	{
		if (source.TipoAtividade == TipoAtividadeEnum.Consulta)
		{
			return context.Mapper.Map<Consulta>(source);
		}
		else if (source.TipoAtividade == TipoAtividadeEnum.Cirurgia)
		{
			return context.Mapper.Map<Cirurgia>(source);
		}

		throw new InvalidOperationException("Tipo de atividade desconhecido.");
	}
}