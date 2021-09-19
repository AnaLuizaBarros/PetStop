using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStop_API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adotante_Endereco_EnderecoId_Endereco",
                table: "Adotante");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Adotante_AdotanteIdAdotante",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Pessoa_PessoaId",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_especie_Animal_ID",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Raca_RacaId_Raca",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId_Endereco",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "idx_Animal_ID",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "Id_Raca",
                table: "Raca",
                newName: "Raca_ID");

            migrationBuilder.RenameColumn(
                name: "EnderecoId_Endereco",
                table: "Pessoa",
                newName: "Endereco_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoa",
                newName: "Pessoa_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_EnderecoId_Endereco",
                table: "Pessoa",
                newName: "IX_Pessoa_Endereco_ID");

            migrationBuilder.RenameColumn(
                name: "Id_Especie",
                table: "Especie",
                newName: "Especie_ID");

            migrationBuilder.RenameColumn(
                name: "Id_Endereco",
                table: "Endereco",
                newName: "Endereco_ID");

            migrationBuilder.RenameColumn(
                name: "RacaId_Raca",
                table: "Animal",
                newName: "Raca_ID");

            migrationBuilder.RenameColumn(
                name: "Animal_ID",
                table: "Animal",
                newName: "Animal_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_RacaId_Raca",
                table: "Animal",
                newName: "IX_Animal_Raca_ID");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Alergia",
                newName: "Pessoa_ID");

            migrationBuilder.RenameColumn(
                name: "AdotanteIdAdotante",
                table: "Alergia",
                newName: "Adotante_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alergia",
                newName: "Alergia_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Alergia_PessoaId",
                table: "Alergia",
                newName: "IX_Alergia_Pessoa_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Alergia_AdotanteIdAdotante",
                table: "Alergia",
                newName: "IX_Alergia_Adotante_ID");

            migrationBuilder.RenameColumn(
                name: "EnderecoId_Endereco",
                table: "Adotante",
                newName: "Endereco_ID");

            migrationBuilder.RenameColumn(
                name: "IdAdotante",
                table: "Adotante",
                newName: "Adotante_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Adotante_EnderecoId_Endereco",
                table: "Adotante",
                newName: "IX_Adotante_Endereco_ID");

            migrationBuilder.AddColumn<int>(
                name: "Especie_ID",
                table: "Animal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "idx_Animal_ID",
                table: "Animal",
                column: "Animal_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Especie_ID",
                table: "Animal",
                column: "Especie_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adotante_Endereco_Endereco_ID",
                table: "Adotante",
                column: "Endereco_ID",
                principalTable: "Endereco",
                principalColumn: "Endereco_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Adotante_Adotante_ID",
                table: "Alergia",
                column: "Adotante_ID",
                principalTable: "Adotante",
                principalColumn: "Adotante_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Pessoa_Pessoa_ID",
                table: "Alergia",
                column: "Pessoa_ID",
                principalTable: "Pessoa",
                principalColumn: "Pessoa_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Especie_Especie_ID",
                table: "Animal",
                column: "Especie_ID",
                principalTable: "Especie",
                principalColumn: "Especie_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Raca_Raca_ID",
                table: "Animal",
                column: "Raca_ID",
                principalTable: "Raca",
                principalColumn: "Raca_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_ID",
                table: "Pessoa",
                column: "Endereco_ID",
                principalTable: "Endereco",
                principalColumn: "Endereco_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adotante_Endereco_Endereco_ID",
                table: "Adotante");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Adotante_Adotante_ID",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Alergia_Pessoa_Pessoa_ID",
                table: "Alergia");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especie_Especie_ID",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Raca_Raca_ID",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_ID",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "idx_Animal_ID",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_Especie_ID",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Especie_ID",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "Raca_ID",
                table: "Raca",
                newName: "Id_Raca");

            migrationBuilder.RenameColumn(
                name: "Endereco_ID",
                table: "Pessoa",
                newName: "EnderecoId_Endereco");

            migrationBuilder.RenameColumn(
                name: "Pessoa_ID",
                table: "Pessoa",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_Endereco_ID",
                table: "Pessoa",
                newName: "IX_Pessoa_EnderecoId_Endereco");

            migrationBuilder.RenameColumn(
                name: "Especie_ID",
                table: "Especie",
                newName: "Id_Especie");

            migrationBuilder.RenameColumn(
                name: "Endereco_ID",
                table: "Endereco",
                newName: "Id_Endereco");

            migrationBuilder.RenameColumn(
                name: "Raca_ID",
                table: "Animal",
                newName: "RacaId_Raca");

            migrationBuilder.RenameColumn(
                name: "Animal_ID",
                table: "Animal",
                newName: "Animal_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_Raca_ID",
                table: "Animal",
                newName: "IX_Animal_RacaId_Raca");

            migrationBuilder.RenameColumn(
                name: "Pessoa_ID",
                table: "Alergia",
                newName: "PessoaId");

            migrationBuilder.RenameColumn(
                name: "Adotante_ID",
                table: "Alergia",
                newName: "AdotanteIdAdotante");

            migrationBuilder.RenameColumn(
                name: "Alergia_ID",
                table: "Alergia",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Alergia_Pessoa_ID",
                table: "Alergia",
                newName: "IX_Alergia_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alergia_Adotante_ID",
                table: "Alergia",
                newName: "IX_Alergia_AdotanteIdAdotante");

            migrationBuilder.RenameColumn(
                name: "Endereco_ID",
                table: "Adotante",
                newName: "EnderecoId_Endereco");

            migrationBuilder.RenameColumn(
                name: "Adotante_ID",
                table: "Adotante",
                newName: "IdAdotante");

            migrationBuilder.RenameIndex(
                name: "IX_Adotante_Endereco_ID",
                table: "Adotante",
                newName: "IX_Adotante_EnderecoId_Endereco");

            migrationBuilder.CreateIndex(
                name: "idx_Animal_ID",
                table: "Animal",
                column: "Animal_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adotante_Endereco_EnderecoId_Endereco",
                table: "Adotante",
                column: "EnderecoId_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Adotante_AdotanteIdAdotante",
                table: "Alergia",
                column: "AdotanteIdAdotante",
                principalTable: "Adotante",
                principalColumn: "IdAdotante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alergia_Pessoa_PessoaId",
                table: "Alergia",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_especie_Animal_ID",
                table: "Animal",
                column: "Animal_ID",
                principalTable: "Especie",
                principalColumn: "Id_Especie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Raca_RacaId_Raca",
                table: "Animal",
                column: "RacaId_Raca",
                principalTable: "Raca",
                principalColumn: "Id_Raca",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId_Endereco",
                table: "Pessoa",
                column: "EnderecoId_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
