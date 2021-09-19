using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStop_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id_Endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Sigla = table.Column<string>(type: "CHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id_Endereco);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id_Especie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id_Especie);
                });

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    Id_Raca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao_Raca = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.Id_Raca);
                });

            migrationBuilder.CreateTable(
                name: "Adotante",
                columns: table => new
                {
                    IdAdotante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "INT", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EnderecoId_Endereco = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adotante", x => x.IdAdotante);
                    table.ForeignKey(
                        name: "FK_Adotante_Endereco_EnderecoId_Endereco",
                        column: x => x.EnderecoId_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id_Endereco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Idade = table.Column<int>(type: "INT", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    EnderecoId_Endereco = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId_Endereco",
                        column: x => x.EnderecoId_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id_Endereco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Animal_ID = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    RacaId_Raca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Animal_ID);
                    table.ForeignKey(
                        name: "FK_Animal_Especie_Animal_ID",
                        column: x => x.Animal_ID,
                        principalTable: "Especie",
                        principalColumn: "Id_Especie");
                        //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Raca_RacaId_Raca",
                        column: x => x.RacaId_Raca,
                        principalTable: "Raca",
                        principalColumn: "Id_Raca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    AdotanteIdAdotante = table.Column<int>(type: "int", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergia_Adotante_AdotanteIdAdotante",
                        column: x => x.AdotanteIdAdotante,
                        principalTable: "Adotante",
                        principalColumn: "IdAdotante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alergia_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_adotante_cpf",
                table: "Adotante",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "idx_adotante_nome",
                table: "Adotante",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "idx_id_adotante",
                table: "Adotante",
                column: "IdAdotante");

            migrationBuilder.CreateIndex(
                name: "IX_Adotante_EnderecoId_Endereco",
                table: "Adotante",
                column: "EnderecoId_Endereco");

            migrationBuilder.CreateIndex(
                name: "idx_id_alergia",
                table: "Alergia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_AdotanteIdAdotante",
                table: "Alergia",
                column: "AdotanteIdAdotante");

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_PessoaId",
                table: "Alergia",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "idx_Animal_ID",
                table: "Animal",
                column: "Animal_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_RacaId_Raca",
                table: "Animal",
                column: "RacaId_Raca");

            migrationBuilder.CreateIndex(
                name: "idx_cidade",
                table: "Endereco",
                column: "Cidade");

            migrationBuilder.CreateIndex(
                name: "idx_estado",
                table: "Endereco",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "idx_Animal_ID",
                table: "Endereco",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "idx_nome_especie",
                table: "Especie",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "idx_cpf_pessoa",
                table: "Pessoa",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "idx_id_pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_nome_pessoa",
                table: "Pessoa",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId_Endereco",
                table: "Pessoa",
                column: "EnderecoId_Endereco");

            migrationBuilder.CreateIndex(
                name: "idx_id_raca",
                table: "Raca",
                column: "Id_Raca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Adotante");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
