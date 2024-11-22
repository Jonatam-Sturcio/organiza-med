using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizaMed.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class addBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAtividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoAtividade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAtividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBMedico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Especialidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    CRM = table.Column<string>(type: "char(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBAtividade_TBMedico",
                columns: table => new
                {
                    AtividadesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAtividade_TBMedico", x => new { x.AtividadesId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_TBAtividade_TBMedico_TBAtividade_AtividadesId",
                        column: x => x.AtividadesId,
                        principalTable: "TBAtividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAtividade_TBMedico_TBMedico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "TBMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAtividade_TBMedico_MedicosId",
                table: "TBAtividade_TBMedico",
                column: "MedicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAtividade_TBMedico");

            migrationBuilder.DropTable(
                name: "TBAtividade");

            migrationBuilder.DropTable(
                name: "TBMedico");
        }
    }
}
