using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseModelClasses.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_CustomRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "CustomRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_CustomRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "CustomRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Make = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Time = table.Column<DateTime>(type: "Time", nullable: false),
                    DestinationAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    MeetingAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    ManifestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.ManifestId);
                    table.ForeignKey(
                        name: "FK_Manifests_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifests_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomRole",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3621), "Administrator Role", "Admin", "ADMIN" },
                    { 2, null, new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3682), "Owner Role", "Owner", "OWNER" },
                    { 3, null, new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3689), "Passenger Role", "Passenger", "PASSENGER" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Springfield", "4e25e28d-14b3-4e88-9422-69347e8a95f0", "USA", new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3806), "Admin", "a@a.a", true, "John", "Doe", false, null, "555-0100", new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3809), "Admin", "A@A.A", "A@A.A", "AQAAAAIAAYagAAAAEFe6SkMhBUxbdXC1DPGLqG8wpbXpt5FtHfvrTorVrar/v5+CPmgahMMR19Gfc9+lMg==", null, false, "12345", "fd95997a-7d5b-42dd-8b6c-1f9e71152d43", "123 Elm St", false, "a@a.a" },
                    { 2, 0, "Metropolis", "7732f772-c4a3-4888-aab7-57e8c9082f85", "USA", new DateTime(2024, 2, 14, 17, 27, 15, 606, DateTimeKind.Local).AddTicks(2973), "Admin", "o@o.o", true, "Jane", "Smith", false, null, "555-0200", new DateTime(2024, 2, 14, 17, 27, 15, 606, DateTimeKind.Local).AddTicks(3051), "Admin", "O@O.O", "O@O.O", "AQAAAAIAAYagAAAAEHOmz1YjfOo0xdSE0KSVX70K366Fz/zkuYsLnxqj/gWW06ga+zfjSeJSKA8TA37/Dg==", null, false, "67890", "c0750046-91de-4b1d-89c9-906385bff45c", "456 Oak St", false, "o@o.o" },
                    { 3, 0, "Gotham", "5935233e-51d7-48af-97fc-230c213d139e", "USA", new DateTime(2024, 2, 14, 17, 27, 15, 711, DateTimeKind.Local).AddTicks(9874), "Admin", "p@p.p", true, "Jim", "Bean", false, null, "555-0300", new DateTime(2024, 2, 14, 17, 27, 15, 711, DateTimeKind.Local).AddTicks(9973), "Admin", "P@P.P", "P@P.P", "AQAAAAIAAYagAAAAEMm3yF4KFgvpn7oHd32JX1+ctVfJupsLSQHPZIpcm34HLD0HaMqZJIXkFh9VYKL2iA==", null, false, "10112", "89808779-bd43-4a29-a3de-a12aba570c20", "789 Pine St", false, "p@p.p" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5401), "Admin", 1, "Generic", "Sedan", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5499), "Admin", 4, "Economy", 2020 },
                    { 2, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5509), "Admin", 2, "FastCars", "Coupe", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5513), "Admin", 2, "Sport", 2019 },
                    { 3, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5601), "Admin", 3, "BigCars", "SUV", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5605), "Admin", 6, "Luxury", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6312), "Admin", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100 Main St, Springfield", "150 Main St, Springfield", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6322), "Admin", new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6340), "Admin", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "200 Main St, Metropolis", "250 Main St, Metropolis", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6344), "Admin", new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6350), "Admin", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "300 Main St, Gotham", "350 Main St, Gotham", new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6353), "Admin", new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Manifests",
                columns: new[] { "ManifestId", "Created", "CreatedBy", "Id", "Modified", "ModifiedBy", "Notes", "TripId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6442), "Admin", 1, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6483), "Admin", "John's trip.", 1 },
                    { 2, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6490), "Admin", 2, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6494), "Admin", "Jane's trip.", 2 },
                    { 3, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6500), "Admin", 3, new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6503), "Admin", "Jim's trip.", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "RoleNameIndex",
                table: "CustomRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_Id",
                table: "Manifests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_TripId",
                table: "Manifests",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Members",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Members",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Id",
                table: "Vehicles",
                column: "Id");
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
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "CustomRole");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
