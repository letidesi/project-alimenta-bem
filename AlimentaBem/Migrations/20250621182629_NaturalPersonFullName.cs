using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alimenta_bem.Migrations
{
    /// <inheritdoc />
    public partial class NaturalPersonFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "NaturalPersons");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "NaturalPersons",
                newName: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "NaturalPersons",
                newName: "lastName");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "NaturalPersons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
