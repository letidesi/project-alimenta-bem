using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alimenta_bem.Migrations
{
    /// <inheritdoc />
    public partial class Donation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    naturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    organizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amountDonated = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Donations_NaturalPersons_naturalPersonId",
                        column: x => x.naturalPersonId,
                        principalTable: "NaturalPersons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Organizations_organizationId",
                        column: x => x.organizationId,
                        principalTable: "Organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_naturalPersonId",
                table: "Donations",
                column: "naturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_organizationId",
                table: "Donations",
                column: "organizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
