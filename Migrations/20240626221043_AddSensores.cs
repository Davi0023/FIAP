using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Challenge.Migrations
{
    /// <inheritdoc />
    public partial class AddSensores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    id_sensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_fabricante = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nm_oceano = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_local = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.id_sensor);
                    table.ForeignKey(
                        name: "FK_Sensores_Local_id_local",
                        column: x => x.id_local,
                        principalTable: "Local",
                        principalColumn: "id_local",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensores_id_local",
                table: "Sensores",
                column: "id_local");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}
