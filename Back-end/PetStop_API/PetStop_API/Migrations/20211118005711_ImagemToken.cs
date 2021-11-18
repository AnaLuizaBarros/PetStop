using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStop_API.Migrations
{
    public partial class ImagemToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Adotante_id_adotante",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Animal_id_animal",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Doador_id_doador",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Especie_id_especie",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergico_Adotante_id_adotante",
                table: "Alergico");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergico_Alergia_id_alergia",
                table: "Alergico");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Doador_id_doador",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Porte_id_porte",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Raca_Especie_id_especie",
                table: "Raca");

            migrationBuilder.DropColumn(
                name: "imagem",
                table: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Raca",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_porte",
                table: "Animal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Animal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_doador",
                table: "Animal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_alergia",
                table: "Alergico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_adotante",
                table: "Alergico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Alergia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_doador",
                table: "Adocao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_animal",
                table: "Adocao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_adotante",
                table: "Adocao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    id_imagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    imagem = table.Column<byte[]>(type: "BLOB", nullable: false),
                    id_animal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.id_imagem);
                    table.ForeignKey(
                        name: "FK_Imagem_Animal_id_animal",
                        column: x => x.id_animal,
                        principalTable: "Animal",
                        principalColumn: "id_animal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_id_animal",
                table: "Imagem",
                column: "id_animal");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Adotante_id_adotante",
                table: "Adocao",
                column: "id_adotante",
                principalTable: "Adotante",
                principalColumn: "id_adotante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Animal_id_animal",
                table: "Adocao",
                column: "id_animal",
                principalTable: "Animal",
                principalColumn: "id_animal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Doador_id_doador",
                table: "Adocao",
                column: "id_doador",
                principalTable: "Doador",
                principalColumn: "id_doador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Especie_id_especie",
                table: "Alergia",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergico_Adotante_id_adotante",
                table: "Alergico",
                column: "id_adotante",
                principalTable: "Adotante",
                principalColumn: "id_adotante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergico_Alergia_id_alergia",
                table: "Alergico",
                column: "id_alergia",
                principalTable: "Alergia",
                principalColumn: "id_alergia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Doador_id_doador",
                table: "Animal",
                column: "id_doador",
                principalTable: "Doador",
                principalColumn: "id_doador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Porte_id_porte",
                table: "Animal",
                column: "id_porte",
                principalTable: "Porte",
                principalColumn: "id_porte",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raca_Especie_id_especie",
                table: "Raca",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Adotante_id_adotante",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Animal_id_animal",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Doador_id_doador",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Especie_id_especie",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergico_Adotante_id_adotante",
                table: "Alergico");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergico_Alergia_id_alergia",
                table: "Alergico");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Doador_id_doador",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Porte_id_porte",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Raca_Especie_id_especie",
                table: "Raca");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Raca",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_porte",
                table: "Animal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Animal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_doador",
                table: "Animal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "imagem",
                table: "Animal",
                type: "VARCHAR(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "id_alergia",
                table: "Alergico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_adotante",
                table: "Alergico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_especie",
                table: "Alergia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_doador",
                table: "Adocao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_animal",
                table: "Adocao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_adotante",
                table: "Adocao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Adotante_id_adotante",
                table: "Adocao",
                column: "id_adotante",
                principalTable: "Adotante",
                principalColumn: "id_adotante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Animal_id_animal",
                table: "Adocao",
                column: "id_animal",
                principalTable: "Animal",
                principalColumn: "id_animal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Doador_id_doador",
                table: "Adocao",
                column: "id_doador",
                principalTable: "Doador",
                principalColumn: "id_doador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Especie_id_especie",
                table: "Alergia",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergico_Adotante_id_adotante",
                table: "Alergico",
                column: "id_adotante",
                principalTable: "Adotante",
                principalColumn: "id_adotante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergico_Alergia_id_alergia",
                table: "Alergico",
                column: "id_alergia",
                principalTable: "Alergia",
                principalColumn: "id_alergia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Doador_id_doador",
                table: "Animal",
                column: "id_doador",
                principalTable: "Doador",
                principalColumn: "id_doador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Especie_id_especie",
                table: "Animal",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Porte_id_porte",
                table: "Animal",
                column: "id_porte",
                principalTable: "Porte",
                principalColumn: "id_porte",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raca_Especie_id_especie",
                table: "Raca",
                column: "id_especie",
                principalTable: "Especie",
                principalColumn: "id_especie",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
