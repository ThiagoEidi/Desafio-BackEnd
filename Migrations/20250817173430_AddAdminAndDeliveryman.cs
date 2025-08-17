using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAndDeliveryman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliverymen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CNH = table.Column<string>(type: "text", nullable: false),
                    CNHType = table.Column<int>(type: "integer", nullable: false),
                    CNHImage = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverymen", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliverymen_CNH",
                table: "Deliverymen",
                column: "CNH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliverymen_CNPJ",
                table: "Deliverymen",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliverymen");
        }
    }
}
