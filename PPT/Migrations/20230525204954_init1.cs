using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPT.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_sections_sectionid",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_departments_departmentid",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "email",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "universityId",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "departmentid",
                table: "doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsContracted",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "sectionid",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "isPublished",
                table: "attendances",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_sections_sectionid",
                table: "departments",
                column: "sectionid",
                principalTable: "sections",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_departments_departmentid",
                table: "doctors",
                column: "departmentid",
                principalTable: "departments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_sections_sectionid",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_departments_departmentid",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "IsContracted",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "universityId",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "departmentid",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rank",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "sectionid",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isPublished",
                table: "attendances",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_sections_sectionid",
                table: "departments",
                column: "sectionid",
                principalTable: "sections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_departments_departmentid",
                table: "doctors",
                column: "departmentid",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
