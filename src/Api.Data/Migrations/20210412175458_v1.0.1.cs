using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoBairro",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCidade",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoEstado",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoNumero",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoRuaAvenida",
                table: "UserEntity",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EnderecoBairro",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EnderecoCidade",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EnderecoEstado",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EnderecoRuaAvenida",
                table: "UserEntity");
        }
    }
}
