using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alimenta_bem.Migrations
{
    /// <inheritdoc />
    public partial class FixVariablesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaturalPersons_Users_UserId",
                table: "NaturalPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Roles",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Roles",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Roles",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Roles",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Roles",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                newName: "IX_Roles_userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "NaturalPersons",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "NaturalPersons",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "SocialName",
                table: "NaturalPersons",
                newName: "socialName");

            migrationBuilder.RenameColumn(
                name: "SkinColor",
                table: "NaturalPersons",
                newName: "skinColor");

            migrationBuilder.RenameColumn(
                name: "Rg",
                table: "NaturalPersons",
                newName: "rg");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "NaturalPersons",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "IsPcd",
                table: "NaturalPersons",
                newName: "isPcd");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "NaturalPersons",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "NaturalPersons",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "NaturalPersons",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "NaturalPersons",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "NaturalPersons",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "BirthdayDate",
                table: "NaturalPersons",
                newName: "birthdayDate");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "NaturalPersons",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NaturalPersons",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_NaturalPersons_UserId",
                table: "NaturalPersons",
                newName: "IX_NaturalPersons_userId");

            migrationBuilder.AlterColumn<int>(
                name: "skinColor",
                table: "NaturalPersons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "gender",
                table: "NaturalPersons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NaturalPersons_Users_userId",
                table: "NaturalPersons",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_userId",
                table: "Roles",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaturalPersons_Users_userId",
                table: "NaturalPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_userId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Roles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Roles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Roles",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "Roles",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Roles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_userId",
                table: "Roles",
                newName: "IX_Roles_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "NaturalPersons",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "NaturalPersons",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "socialName",
                table: "NaturalPersons",
                newName: "SocialName");

            migrationBuilder.RenameColumn(
                name: "skinColor",
                table: "NaturalPersons",
                newName: "SkinColor");

            migrationBuilder.RenameColumn(
                name: "rg",
                table: "NaturalPersons",
                newName: "Rg");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "NaturalPersons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "isPcd",
                table: "NaturalPersons",
                newName: "IsPcd");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "NaturalPersons",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "NaturalPersons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "NaturalPersons",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "NaturalPersons",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "NaturalPersons",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "birthdayDate",
                table: "NaturalPersons",
                newName: "BirthdayDate");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "NaturalPersons",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NaturalPersons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_NaturalPersons_userId",
                table: "NaturalPersons",
                newName: "IX_NaturalPersons_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SkinColor",
                table: "NaturalPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "NaturalPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NaturalPersons_Users_UserId",
                table: "NaturalPersons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
