using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizaMed.Dominio.Compartilhado;
using OrganizaMed.Dominio.Entidades;
using OrganizaMed.Dominio.ModuloAtividade;

namespace OrganizaMed.Infra.Orm.ModuloAtividades;

public class MapeadorAtividadeOrm : IEntityTypeConfiguration<AtividadeBase>
{
	public void Configure(EntityTypeBuilder<AtividadeBase> builder)
	{
		builder.ToTable("TBAtividade");

		builder.HasDiscriminator(x => x.TipoAtividade)
			.HasValue<Consulta>(TipoAtividadeEnum.Consulta)
			.HasValue<Cirurgia>(TipoAtividadeEnum.Cirurgia);

		builder.Property(x => x.HoraInicio).IsRequired().HasColumnType("datetime2");
		builder.Property(x => x.HoraTermino).IsRequired().HasColumnType("datetime2");
		builder.HasMany(x => x.Medicos).WithMany(x => x.Atividades).UsingEntity("TBAtividade_TBMedico");
		builder.Property(x => x.TipoAtividade).IsRequired().HasColumnType("int");
	}
}