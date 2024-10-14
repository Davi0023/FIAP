using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Challenge.Migrations
{
    /// <inheritdoc />
    public partial class AddOrgao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_orgao",
                table: "Local",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orgao",
                columns: table => new
                {
                    id_orgao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_orgao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nr_ddi = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NrDdd = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_telefone = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nr_numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgao", x => x.id_orgao);
                });

            migrationBuilder.CreateTable(
                name: "Poluente",
                columns: table => new
                {
                    id_poluente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_poluente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tp_poluente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poluente", x => x.id_poluente);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    id_ocorrencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_ocorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_sensor = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_poluente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Poluenteid_poluente = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.id_ocorrencia);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Poluente_Poluenteid_poluente",
                        column: x => x.Poluenteid_poluente,
                        principalTable: "Poluente",
                        principalColumn: "id_poluente");
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Sensores_id_sensor",
                        column: x => x.id_sensor,
                        principalTable: "Sensores",
                        principalColumn: "id_sensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Local_id_orgao",
                table: "Local",
                column: "id_orgao");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_id_sensor",
                table: "Ocorrencia",
                column: "id_sensor");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_Poluenteid_poluente",
                table: "Ocorrencia",
                column: "Poluenteid_poluente");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Orgao_id_orgao",
                table: "Local",
                column: "id_orgao",
                principalTable: "Orgao",
                principalColumn: "id_orgao",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Orgao_id_orgao",
                table: "Local");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Orgao");

            migrationBuilder.DropTable(
                name: "Poluente");

            migrationBuilder.DropIndex(
                name: "IX_Local_id_orgao",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "id_orgao",
                table: "Local");
        }
    }
}
