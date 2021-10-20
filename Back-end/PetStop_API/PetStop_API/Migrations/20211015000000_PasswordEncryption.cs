using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStop_API.Migrations
{
    public partial class PasswordEncryption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Doador",
                type: "VARCHAR(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Adotante",
                type: "VARCHAR(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Doador",
                type: "VARCHAR(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(32)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Adotante",
                type: "VARCHAR(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(32)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}