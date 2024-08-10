using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alimenta_bem.Migrations
{
    /// <inheritdoc />
    public partial class NaturalPersonRemoveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "NaturalPersons");

            migrationBuilder.DropColumn(
                name: "rg",
                table: "NaturalPersons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "NaturalPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rg",
                table: "NaturalPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
