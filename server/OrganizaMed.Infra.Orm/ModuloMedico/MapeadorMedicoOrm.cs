﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Infra.Orm.ModuloMedico;

public class MapeadorMedicoOrm : IEntityTypeConfiguration<Medico>
{
	public void Configure(EntityTypeBuilder<Medico> builder)
	{
		builder.ToTable("TBMedico");

		builder.Property(x => x.Id).ValueGeneratedNever();
		builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
		builder.Property(x => x.Especialidade).HasColumnType("varchar(200)").IsRequired();
		builder.Property(x => x.CRM).HasColumnType("char(8)").IsRequired();
	}
}