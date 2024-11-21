﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizaMed.Infra.Orm.Compartilhado;

#nullable disable

namespace OrganizaMed.Infra.Orm.Migrations
{
    [DbContext(typeof(OrganizaMedDbContext))]
    [Migration("20241121194338_Banco")]
    partial class Banco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrganizaMed.Dominio.Compartilhado.AtividadeBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraTermino")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoAtividade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBAtividade", (string)null);

                    b.HasDiscriminator<int>("TipoAtividade");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OrganizaMed.Dominio.ModuloMedico.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TBMedico", (string)null);
                });

            modelBuilder.Entity("TBAtividade_TBMedico", b =>
                {
                    b.Property<Guid>("AtividadesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AtividadesId", "MedicosId");

                    b.HasIndex("MedicosId");

                    b.ToTable("TBAtividade_TBMedico");
                });

            modelBuilder.Entity("OrganizaMed.Dominio.Entidades.Cirurgia", b =>
                {
                    b.HasBaseType("OrganizaMed.Dominio.Compartilhado.AtividadeBase");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("OrganizaMed.Dominio.ModuloAtividade.Consulta", b =>
                {
                    b.HasBaseType("OrganizaMed.Dominio.Compartilhado.AtividadeBase");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("TBAtividade_TBMedico", b =>
                {
                    b.HasOne("OrganizaMed.Dominio.Compartilhado.AtividadeBase", null)
                        .WithMany()
                        .HasForeignKey("AtividadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrganizaMed.Dominio.ModuloMedico.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
