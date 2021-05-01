using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnderecoReferencia",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "UserEntity",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoReferencia",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "UserEntity");
        }
    }
}
