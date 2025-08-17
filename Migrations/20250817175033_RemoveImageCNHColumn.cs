using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageCNHColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNHImage",
                table: "Deliverymen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNHImage",
                table: "Deliverymen",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
