using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeladeiraSOLID.Migrations
{
    /// <inheritdoc />
    public partial class RemoverCampoValido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valido",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Valido",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
