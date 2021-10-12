using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PetStop_API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adotante",
                columns: table => new
                {
                    id_adotante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "VARCHAR(12)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf = table.Column<string>(type: "VARCHAR(14)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "VARCHAR(14)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rua = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adotante", x => x.id_adotante);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doador",
                columns: table => new
                {
                    id_doador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "VARCHAR(12)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf = table.Column<string>(type: "VARCHAR(14)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "VARCHAR(14)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rua = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doador", x => x.id_doador);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    id_especie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.id_especie);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Porte",
                columns: table => new
                {
                    id_porte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porte", x => x.id_porte);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alergia",
                columns: table => new
                {
                    id_alergia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_especie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergia", x => x.id_alergia);
                    table.ForeignKey(
                        name: "FK_Alergia_Especie_id_especie",
                        column: x => x.id_especie,
                        principalTable: "Especie",
                        principalColumn: "id_especie",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    id_raca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_especie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.id_raca);
                    table.ForeignKey(
                        name: "FK_Raca_Especie_id_especie",
                        column: x => x.id_especie,
                        principalTable: "Especie",
                        principalColumn: "id_especie",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    id_animal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_especie = table.Column<int>(type: "int", nullable: true),
                    imagem = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_doador = table.Column<int>(type: "int", nullable: true),
                    id_porte = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.id_animal);
                    table.ForeignKey(
                        name: "FK_Animal_Doador_id_doador",
                        column: x => x.id_doador,
                        principalTable: "Doador",
                        principalColumn: "id_doador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Especie_id_especie",
                        column: x => x.id_especie,
                        principalTable: "Especie",
                        principalColumn: "id_especie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Porte_id_porte",
                        column: x => x.id_porte,
                        principalTable: "Porte",
                        principalColumn: "id_porte",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alergico",
                columns: table => new
                {
                    id_alergico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_alergia = table.Column<int>(type: "int", nullable: true),
                    id_adotante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergico", x => x.id_alergico);
                    table.ForeignKey(
                        name: "FK_Alergico_Adotante_id_adotante",
                        column: x => x.id_adotante,
                        principalTable: "Adotante",
                        principalColumn: "id_adotante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alergico_Alergia_id_alergia",
                        column: x => x.id_alergia,
                        principalTable: "Alergia",
                        principalColumn: "id_alergia",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adocao",
                columns: table => new
                {
                    id_adocao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataAdocao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    id_doador = table.Column<int>(type: "int", nullable: true),
                    id_adotante = table.Column<int>(type: "int", nullable: true),
                    id_animal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adocao", x => x.id_adocao);
                    table.ForeignKey(
                        name: "FK_Adocao_Adotante_id_adotante",
                        column: x => x.id_adotante,
                        principalTable: "Adotante",
                        principalColumn: "id_adotante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adocao_Animal_id_animal",
                        column: x => x.id_animal,
                        principalTable: "Animal",
                        principalColumn: "id_animal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adocao_Doador_id_doador",
                        column: x => x.id_doador,
                        principalTable: "Doador",
                        principalColumn: "id_doador",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_id_adotante",
                table: "Adocao",
                column: "id_adotante");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_id_animal",
                table: "Adocao",
                column: "id_animal");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_id_doador",
                table: "Adocao",
                column: "id_doador");

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_id_especie",
                table: "Alergia",
                column: "id_especie");

            migrationBuilder.CreateIndex(
                name: "IX_Alergico_id_adotante",
                table: "Alergico",
                column: "id_adotante");

            migrationBuilder.CreateIndex(
                name: "IX_Alergico_id_alergia",
                table: "Alergico",
                column: "id_alergia");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_id_doador",
                table: "Animal",
                column: "id_doador");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_id_especie",
                table: "Animal",
                column: "id_especie");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_id_porte",
                table: "Animal",
                column: "id_porte");

            migrationBuilder.CreateIndex(
                name: "IX_Raca_id_especie",
                table: "Raca",
                column: "id_especie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adocao");

            migrationBuilder.DropTable(
                name: "Alergico");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Adotante");

            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Doador");

            migrationBuilder.DropTable(
                name: "Porte");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}