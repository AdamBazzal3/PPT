using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeanID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Faculties_AspNetUsers_DeanID",
                        column: x => x.DeanID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    DirectorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branches_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    SecretaryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HeadID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_HeadID",
                        column: x => x.HeadID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_SecretaryID",
                        column: x => x.SecretaryID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsContracted = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attendances_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32100e5b-2726-4b59-8d18-aaaed11da14a", "5e90fdd0-a53d-473f-abe4-2e8b2aad4c8f", "Manager", "MANAGER" },
                    { "7e945523-6d0c-4c37-92fd-a8f726e6b6e9", "07489521-4f3e-4601-bd7c-23509bf4a5c5", "Secretary", "SECRETARY" },
                    { "eb3ff27a-17e5-4216-b80b-8829657615c9", "09b309f3-778f-4167-a9ee-55d61f004190", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-7u7u-9443d048cdb9", 0, "4a73b8d3-d1e8-422d-ada8-3ee61230420b", "User", "hanaa666@gmail.com", true, "هناء", "", false, null, null, "SECRETARY", "AQAAAAEAACcQAAAAEMxqErIMdCcadgVrOztUOzZQF57+u72QCICP4/a/T9DB2zUgwQFjwVxlaAEf8S9q2g==", null, false, "3b24880f-777c-4eba-a613-9f37aedbe594", false, "Secretary" },
                    { "8e445865-a24d-4543-9O9O-9443d048cdb9", 0, "357e3ecb-0d03-4b5a-a12d-b9b9eed16c83", "User", "bassem666@gmail.com", true, "باسم", "", false, null, null, "SECRETARYBASSEM", "AQAAAAEAACcQAAAAEEELYV6wEOQ8ocPVvStWUbbqhSa5fkhYeWhfentg3HW4VGcgcRN+llDngEYahq6FRg==", null, false, "59389d7a-cd51-44b5-b198-750419dd37cd", false, "SecretaryBassem" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "286f857c-86ef-4e90-8c7d-4c1f688a9ab4", "User", "zainab.alsaghir@gmail.com", true, "زينب ", "الصغير", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIadPCtCYLp0lWNWJrP+BEFEqq8TLAfbA93tIqny6S8wg1FQ1bb7ZnN872/nZFL+6g==", null, false, "9dde4197-6a17-4cae-b336-e541107d10c6", false, "Admin" },
                    { "8e445865-a24d-4543-i9i9-9443d048cdb9", 0, "13070ba3-f39e-4168-b613-8bb6ea3589c4", "User", "hsayn.bazzi666@gmail.com", true, "حسين", "بزي", false, null, null, "MANAGER", "AQAAAAEAACcQAAAAELTR31SmWohQXGwjtQFMZQuhFz5vW/hR2PlqoyYtZCvfZ60w6yGsrPqoCXO7qFbQxw==", null, false, "920e006b-d579-44ae-a2a5-7872767ba939", false, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "DirectorID", "FacultyID", "Name" },
                values: new object[] { 1, null, null, "زحلة" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "ID", "DeanID", "Name" },
                values: new object[] { 1, null, "كلية العلوم" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7e945523-6d0c-4c37-92fd-a8f726e6b6e9", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { "7e945523-6d0c-4c37-92fd-a8f726e6b6e9", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { "eb3ff27a-17e5-4216-b80b-8829657615c9", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "32100e5b-2726-4b59-8d18-aaaed11da14a", "8e445865-a24d-4543-i9i9-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "DirectorID", "FacultyID", "Name" },
                values: new object[] { 2, "8e445865-a24d-4543-i9i9-9443d048cdb9", null, "الحدت" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "BranchID", "HeadID", "Name", "SecretaryID" },
                values: new object[,]
                {
                    { 2, 1, null, "Physics", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { 3, 1, null, "Chemistry", null },
                    { 1, 2, "8e445865-a24d-4543-a6c6-9443d048cdb9", "Computer science and mathmatics", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { 4, 2, null, "Biochemistry", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "DepartmentID", "IsContracted", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 5, 2, false, "سامر", null },
                    { 6, 2, false, "أحمد", null },
                    { 1, 1, true, "علي غريب", null },
                    { 2, 1, true, "محمد دبوق", null },
                    { 3, 1, false, "كمال بيضون", null },
                    { 4, 1, false, "أحمد فاعور", null },
                    { 7, 1, false, "خالد نجار", null },
                    { 8, 1, false, "محمد حسن", null },
                    { 9, 1, false, "فاطمة صالح", null },
                    { 10, 1, false, "ياسر مصطفى", null },
                    { 11, 1, false, "نورا محمود", null }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "ID", "Date", "DoctorID", "Duration", "IsPublished" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1062), 3, null, false },
                    { 2, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1124), 1, null, false },
                    { 3, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1132), 1, null, false },
                    { 4, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1140), 2, null, false },
                    { 5, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1148), 7, null, false },
                    { 6, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1155), 8, null, false },
                    { 7, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1163), 9, null, false },
                    { 8, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1170), 10, null, false },
                    { 9, new DateTime(2023, 7, 18, 8, 21, 51, 352, DateTimeKind.Local).AddTicks(1177), 11, null, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_DoctorID_Date",
                table: "Attendances",
                columns: new[] { "DoctorID", "Date" },
                unique: true,
                filter: "[DoctorID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DirectorID",
                table: "Branches",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_FacultyID",
                table: "Branches",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchID",
                table: "Departments",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadID",
                table: "Departments",
                column: "HeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SecretaryID",
                table: "Departments",
                column: "SecretaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DeanID",
                table: "Faculties",
                column: "DeanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
