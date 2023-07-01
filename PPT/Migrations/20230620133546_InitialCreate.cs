using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Faculties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.ID);
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
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
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
                    SecretaryID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
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
                    IsContracted = table.Column<bool>(type: "bit", nullable: true),
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
                    { "5d9fe5a3-461e-42b7-8afb-2a76cb616dfd", "67ab664d-fcc5-4427-bfb1-3d59a9dffd24", "Manager", "MANAGER" },
                    { "6228eb64-eb6f-4861-8171-c515e76d73d1", "e33cdb58-77bb-40b0-820c-51da6899d178", "Secretary", "SECRETARY" },
                    { "83cfd5bc-f044-4874-8dad-609e0a0076ea", "dfcb7738-16b8-46e9-a306-f97ecd783891", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-7u7u-9443d048cdb9", 0, "20175ef5-b478-466e-bacc-211ab3019b6c", "User", "hanaa666@gmail.com", true, "هناء", "", false, null, null, "SECRETARY", "AQAAAAEAACcQAAAAEF6O5bEGsq1g5tBMrLgnPrtzdVT+lhAWuj9eCOgQqqjc00VbXoMa/cdMXcZlEc4WBg==", null, false, "d8ba0526-2d00-450d-8884-a1c3bc900369", false, "Secretary" },
                    { "8e445865-a24d-4543-9O9O-9443d048cdb9", 0, "b89ed5d4-b2b4-4ef5-813e-b35e6d907b6b", "User", "bassem666@gmail.com", true, "باسم", "", false, null, null, "SECRETARYBASSEM", "AQAAAAEAACcQAAAAEJG7jcoHC+Rp/lHw/sQ7jvv8xzMOKdrp9cRY3QbfWrFV7fVnuAhmeG033XbGqRYHcg==", null, false, "6a4f5526-635f-4888-af7b-cfef8ed751cb", false, "SecretaryBassem" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "7bfd9e0a-1a92-48aa-9365-c29795b0a11d", "User", "zainab.alsaghir@gmail.com", true, "زينب ", "الصغير", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEG4D4tpSOKs8LASGx0HxY/rXIQ/Ddm0hYXWsxsKURl97opUXG/27qTZLMjazRJTzjQ==", null, false, "e86bd978-418b-478a-b56e-5849aecac935", false, "Admin" },
                    { "8e445865-a24d-4543-i9i9-9443d048cdb9", 0, "80f44140-e183-428d-92ad-92556c1d8678", "User", "hsayn.bazzi666@gmail.com", true, "حسين", "بزي", false, null, null, "MANAGER", "AQAAAAEAACcQAAAAEIFlquiMlQjg0jE/uzC7BA/u4uQlbQJdudOHKhYMl3NxAkQzUF/nDjWXfXvvt9sEzQ==", null, false, "207319e7-39d6-4204-9bdb-5ba4c91df7d7", false, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "FacultyID", "Name" },
                values: new object[,]
                {
                    { 1, null, "زحلة" },
                    { 2, null, "الحدت" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "كلية العلوم" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6228eb64-eb6f-4861-8171-c515e76d73d1", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { "6228eb64-eb6f-4861-8171-c515e76d73d1", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { "83cfd5bc-f044-4874-8dad-609e0a0076ea", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "5d9fe5a3-461e-42b7-8afb-2a76cb616dfd", "8e445865-a24d-4543-i9i9-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "BranchID", "Name", "SecretaryID" },
                values: new object[,]
                {
                    { 1, 2, "Computer science and mathmatics", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { 2, 1, "Physics", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { 3, 1, "Chemistry", null },
                    { 4, 2, "Biochemistry", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "DepartmentID", "IsContracted", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, 1, true, "علي غريب", null },
                    { 2, 1, true, "محمد دبوق", null },
                    { 3, 1, null, "كمال بيضون", null },
                    { 4, 1, null, "أحمد فاعور", null },
                    { 5, 2, null, "سامر", null },
                    { 6, 2, null, "أحمد", null }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "ID", "Date", "DoctorID", "Duration", "IsPublished" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 20, 16, 35, 46, 253, DateTimeKind.Local).AddTicks(1782), 3, null, false },
                    { 2, new DateTime(2023, 6, 20, 16, 35, 46, 253, DateTimeKind.Local).AddTicks(1829), 1, null, false },
                    { 3, new DateTime(2023, 6, 20, 16, 35, 46, 253, DateTimeKind.Local).AddTicks(1836), 1, null, false },
                    { 4, new DateTime(2023, 6, 20, 16, 35, 46, 253, DateTimeKind.Local).AddTicks(1840), 2, null, false }
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
                name: "IX_Attendances_DoctorID",
                table: "Attendances",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_FacultyID",
                table: "Branches",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchID",
                table: "Departments",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SecretaryID",
                table: "Departments",
                column: "SecretaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");
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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
