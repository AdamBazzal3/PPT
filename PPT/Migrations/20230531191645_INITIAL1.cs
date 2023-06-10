using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPT.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Sections_SectionID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Departments_DepartmentID",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b467e238-5fcc-49ce-b85c-0d5a40f30ae6", "8e445865-a24d-4543-7u7u-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64c0bac3-9025-42a6-9f3c-744e361b4cf7", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96", "8e445865-a24d-4543-i9i9-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c0bac3-9025-42a6-9f3c-744e361b4cf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b467e238-5fcc-49ce-b85c-0d5a40f30ae6");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsContracted",
                table: "Doctors",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionID",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Attendances",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f36dfcd-5e1a-4f1e-969c-8e42538de2a0", "f2615ea2-62c1-4b73-8a42-fc30e0b39ec0", "Manager", "MANAGER" },
                    { "69552fb4-7220-40df-b952-6b097a0ee04d", "b8c18c96-034c-4ae3-a604-5b117ce6ac32", "Secretary", "SECRETARY" },
                    { "c9283329-c9e1-4a3c-9b35-1d283632fd4a", "cb1bff9a-f004-4b84-92f5-ba865f10d9d4", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-7u7u-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50ba1407-4dc0-40e1-95ce-e584f1c48e97", "AQAAAAEAACcQAAAAEIeXDUhaKQeOSlFjSWOhVLnBxrHJ58P51wQ9nvUowcFUX9nXSdk8d/WoSGZ/Wzd2rA==", "8c410e1c-853e-4594-a134-58001744f0a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab235e24-a4c6-4b25-8f1b-133f153eca2e", "AQAAAAEAACcQAAAAEOJsiDU/dIsCirWxWD2SUaJQzGdPDh8kfzUjePioUil4f44COQH9R5e+h5LcWz12vg==", "6ed345ad-3143-4ac4-a36c-25ac02eb1afe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-i9i9-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e60d2978-6ecf-40f3-9bdc-c0adec822485", "AQAAAAEAACcQAAAAEHhSaqWgAABjvODIuH4E4Uxo+3YnFI0YeZU/PQrhCzQIlmRDs1cNft2OTuF8ZYDEww==", "eff55c45-45d0-4e5f-8fa5-0cc1ea48f085" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 1,
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 2,
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 3,
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 4,
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 1,
                column: "IsContracted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 2,
                column: "IsContracted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 3,
                column: "IsContracted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 4,
                column: "IsContracted",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "69552fb4-7220-40df-b952-6b097a0ee04d", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { "c9283329-c9e1-4a3c-9b35-1d283632fd4a", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "3f36dfcd-5e1a-4f1e-969c-8e42538de2a0", "8e445865-a24d-4543-i9i9-9443d048cdb9" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Sections_SectionID",
                table: "Departments",
                column: "SectionID",
                principalTable: "Sections",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Departments_DepartmentID",
                table: "Doctors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Sections_SectionID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Departments_DepartmentID",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "69552fb4-7220-40df-b952-6b097a0ee04d", "8e445865-a24d-4543-7u7u-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9283329-c9e1-4a3c-9b35-1d283632fd4a", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f36dfcd-5e1a-4f1e-969c-8e42538de2a0", "8e445865-a24d-4543-i9i9-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f36dfcd-5e1a-4f1e-969c-8e42538de2a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69552fb4-7220-40df-b952-6b097a0ee04d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9283329-c9e1-4a3c-9b35-1d283632fd4a");

            migrationBuilder.DropColumn(
                name: "IsContracted",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeLocation",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Rank",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SectionID",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64c0bac3-9025-42a6-9f3c-744e361b4cf7", "57ab0584-18bd-42b8-9db5-cd1674deb634", "Administrator", "ADMINISTRATOR" },
                    { "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96", "82e6b33c-1a40-4285-9346-cba810d11a31", "Manager", "MANAGER" },
                    { "b467e238-5fcc-49ce-b85c-0d5a40f30ae6", "8519a517-729c-43d3-9367-36c15a120fa8", "Secretary", "SECRETARY" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-7u7u-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0bba5f3-d797-451c-aa37-bd59a71340f9", "AQAAAAEAACcQAAAAEBp1LTi3PrSKUmJ3pT0wwnO1cNfRgMgDv4j1TC+C9X7PGCCk22WEdLZIxsEmox0QIQ==", "94d2105c-09c1-48ad-87b3-d4f09679c945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d8e85ee-c32c-41c5-ab4a-eaf2a981bf44", "AQAAAAEAACcQAAAAEP0q8UK4cejvJZK6exiup5FdZYwkXVdRiebSmaaHnRKhjn0KzRIZaL+zLZNok5WkKA==", "bb5c950f-0ec9-46f0-93a5-1ecc4b87657d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-i9i9-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5535b902-6b6f-477d-9682-ae636b77aeed", "AQAAAAEAACcQAAAAEFn963xklBUYP77hBK1rapnJNlZilp972RKOuCtIThc+ydyTJ1z2CJD0XyGRrG13Yg==", "3997bc95-705a-4e0b-bdb0-938a45f82ed4" });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 1,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 2,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 3,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "ID",
                keyValue: 4,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Email", "OfficeLocation", "Rank" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Email", "OfficeLocation", "Rank" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Email", "OfficeLocation", "Rank" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Email", "OfficeLocation", "Rank" },
                values: new object[] { null, null, false });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b467e238-5fcc-49ce-b85c-0d5a40f30ae6", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { "64c0bac3-9025-42a6-9f3c-744e361b4cf7", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96", "8e445865-a24d-4543-i9i9-9443d048cdb9" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Sections_SectionID",
                table: "Departments",
                column: "SectionID",
                principalTable: "Sections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Departments_DepartmentID",
                table: "Doctors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
