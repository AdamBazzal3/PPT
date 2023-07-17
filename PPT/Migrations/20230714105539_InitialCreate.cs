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
                    { "01828a2f-9c17-49af-8b0d-16105eae309c", "e67a6e99-0180-43f4-80e2-bfe5e14b66de", "Secretary", "SECRETARY" },
                    { "5cb0282a-059b-47dd-b90e-3b749ac153af", "27b7ffce-ce69-4b53-917b-a6cc8ab34056", "Administrator", "ADMINISTRATOR" },
                    { "972381b6-e45f-49ad-adfe-bc6a1f0e8cb0", "d6c8a4c7-7eda-40c2-a195-ee1d37b6f24e", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-7u7u-9443d048cdb9", 0, "8d7f0641-5053-435a-82e0-64768e8e35ba", "User", "hanaa666@gmail.com", true, "هناء", "", false, null, null, "SECRETARY", "AQAAAAEAACcQAAAAECQwjzMe6wJncSQqnIiQtK+r9161Q7QbU1ksGsVj5vEoQtTfzUtC7kfoupJpyvXVIQ==", null, false, "d18bb80b-d9d9-4843-a4a7-c6ea695f9acb", false, "Secretary" },
                    { "8e445865-a24d-4543-9O9O-9443d048cdb9", 0, "2b63d95d-4620-4e58-b641-f9129f619db4", "User", "bassem666@gmail.com", true, "باسم", "", false, null, null, "SECRETARYBASSEM", "AQAAAAEAACcQAAAAEOpW36FWge8lBV5/UMZqxgGOICKlqsK/ZSFUq6rOBK8KdeVwEOmhfwN0TnzmZSfWqg==", null, false, "aa0ddf1a-bbc2-45e5-b4c2-c98adf35a793", false, "SecretaryBassem" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "43e87ac5-0ae0-4a26-a5c5-aa8563fcf09c", "User", "zainab.alsaghir@gmail.com", true, "زينب ", "الصغير", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEtzrnIJl2TRgucJ/cKrN6QH0OR64oRWFUO79JBO+LTFlcknDMnShmhQGnssvLU9iA==", null, false, "5d07b3ea-3633-40ed-9b90-be9edf5b5abd", false, "Admin" },
                    { "8e445865-a24d-4543-i9i9-9443d048cdb9", 0, "5a4c445d-dbed-42b9-bb1f-6bb87039a18e", "User", "hsayn.bazzi666@gmail.com", true, "حسين", "بزي", false, null, null, "MANAGER", "AQAAAAEAACcQAAAAEA9PRbHxW1prqxdtAJSjeob+F1ZdY//b0PBlyVyFhaJ2g825dDzGyZYywb1Hc6CJig==", null, false, "b7ae4e82-1450-4c11-bd14-6c76f774d321", false, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "DirectorID", "FacultyID", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "زحلة" },
                    { 2, null, null, "الحدت" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "ID", "DeanID", "Name" },
                values: new object[] { 1, null, "كلية العلوم" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "01828a2f-9c17-49af-8b0d-16105eae309c", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { "01828a2f-9c17-49af-8b0d-16105eae309c", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { "5cb0282a-059b-47dd-b90e-3b749ac153af", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "972381b6-e45f-49ad-adfe-bc6a1f0e8cb0", "8e445865-a24d-4543-i9i9-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "BranchID", "HeadID", "Name", "SecretaryID" },
                values: new object[,]
                {
                    { 1, 2, "8e445865-a24d-4543-a6c6-9443d048cdb9", "Computer science and mathmatics", "8e445865-a24d-4543-7u7u-9443d048cdb9" },
                    { 2, 1, null, "Physics", "8e445865-a24d-4543-9O9O-9443d048cdb9" },
                    { 3, 1, null, "Chemistry", null },
                    { 4, 2, null, "Biochemistry", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "DepartmentID", "IsContracted", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, 1, true, "علي غريب", null },
                    { 2, 1, true, "محمد دبوق", null },
                    { 3, 1, false, "كمال بيضون", null },
                    { 4, 1, false, "أحمد فاعور", null },
                    { 5, 2, false, "سامر", null },
                    { 6, 2, false, "أحمد", null },
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
                    { 1, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5582), 3, null, false },
                    { 2, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5619), 1, null, false },
                    { 3, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5621), 1, null, false },
                    { 4, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5624), 2, null, false },
                    { 5, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5627), 7, null, false },
                    { 6, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5629), 8, null, false },
                    { 7, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5632), 9, null, false },
                    { 8, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5635), 10, null, false },
                    { 9, new DateTime(2023, 7, 14, 13, 55, 39, 436, DateTimeKind.Local).AddTicks(5637), 11, null, false }
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
