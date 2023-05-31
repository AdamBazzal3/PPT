using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPT.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "officeLocation",
                table: "doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "officeLocation",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
