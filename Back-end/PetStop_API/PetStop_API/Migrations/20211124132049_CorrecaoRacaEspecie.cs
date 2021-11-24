using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStop_API.Migrations
{
    public partial class CorrecaoRacaEspecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "id_especie",
                table: "Animal",
                newName: "id_raca");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_id_especie",
                table: "Animal",
                newName: "IX_Animal_id_raca");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Raca_id_raca",
                table: "Animal",
                column: "id_raca",
                principalTable: "Raca",
                principalColumn: "id_raca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Raca_id_raca",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "id_raca",
                table: "Animal",
                newName: "id_especie");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_id_raca",
                table: "Animal",
                newName: "IX_Animal_id_especie");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
