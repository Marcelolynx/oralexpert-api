using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eleven.OralExpert.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTelefoneToClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Clinics",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Clinics");
        }
    }
}
