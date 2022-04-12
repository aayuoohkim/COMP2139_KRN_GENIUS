using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_KRN_GENIUS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId");
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "South Korea" },
                    { 2, "North Korea" },
                    { 3, "United States" },
                    { 4, "Canada" },
                    { 5, "England" },
                    { 6, "Russia" },
                    { 7, "Japan" },
                    { 8, "France" },
                    { 9, "Italy" },
                    { 10, "China" },
                    { 11, "Ukraine" },
                    { 12, "Australia" },
                    { 13, "Argentina" },
                    { 14, "Vietnam" },
                    { 15, "Thailand" },
                    { 16, "Brazil" },
                    { 17, "Syria" },
                    { 18, "Nepal" },
                    { 19, "Mexico" },
                    { 20, "Malaysia" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Date", "Name", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "TRNY10", new DateTime(2020, 3, 1, 8, 23, 0, 0, DateTimeKind.Unspecified), "Tournament Master 1.0", 4.9900000000000002 },
                    { 2, "LEAG10", new DateTime(2020, 7, 26, 15, 28, 0, 0, DateTimeKind.Unspecified), "League Scheduler 1.0", 4.9900000000000002 },
                    { 3, "LEAGD10", new DateTime(2020, 8, 3, 12, 30, 0, 0, DateTimeKind.Unspecified), "League Scheduler Deluxe 1.0", 6.9900000000000002 },
                    { 4, "DRAFT10", new DateTime(2020, 8, 15, 9, 15, 0, 0, DateTimeKind.Unspecified), "Draft Manager 1.0", 4.9900000000000002 },
                    { 5, "TEAM10", new DateTime(2020, 9, 3, 11, 42, 0, 0, DateTimeKind.Unspecified), "Team Manager 1.0", 4.9900000000000002 },
                    { 6, "TRNY20", new DateTime(2020, 10, 30, 9, 43, 0, 0, DateTimeKind.Unspecified), "Tournament Manager 2.0", 7.9900000000000002 },
                    { 7, "DRAFT20", new DateTime(2020, 11, 5, 14, 3, 0, 0, DateTimeKind.Unspecified), "Draft Manager 2.0", 5.9900000000000002 },
                    { 8, "LEAGD20", new DateTime(2020, 11, 10, 9, 35, 0, 0, DateTimeKind.Unspecified), "League Schedular Deluxe 2.0", 5.9900000000000002 },
                    { 9, "DRAFT30", new DateTime(2020, 11, 20, 16, 49, 0, 0, DateTimeKind.Unspecified), "Draft Manager 3.0", 5.9900000000000002 },
                    { 10, "TEAM20", new DateTime(2020, 12, 15, 17, 42, 0, 0, DateTimeKind.Unspecified), "Team Manager 2.0", 6.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "yimsh4507@gmail.com", "Seunghun Yim", "647-551-3087" },
                    { 2, "aayuooh233@gmail.com", "Yoonhee Kim", "647-551-1233" },
                    { 3, "jysong304@gmail.com", "JooYoung Song", "432-132-1404" },
                    { 4, "tony99@gmail.com", "Anthony Edward Stark", "232-932-3921" },
                    { 5, "russia23@gmail.com", "Natasha Romanoff", "432-132-1404" },
                    { 6, "hawkI99@gmail.com", "Clint Barton", "432-882-0231" },
                    { 7, "warmachine34@gmail.com", "James Rhodes", "842-949-0100" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "13 Asrahi ave", "Vaughan", 3, "evans34@gmail.com", "Steve", "Rogers", "415-222-9723", "K2E 4B3", "Ontario" },
                    { 2, "99 Glass st", "Toronto", 1, "metalarm@gmail.com", "Bucky", "Barnes", "423-523-1233", "M6M 4B5", "Ontario" },
                    { 3, "14 Maximum ct", "Richmond", 4, "vision34@gmail.com", "Wanda", "Maximoff", "953-992-3111", "M3M 1B1", "Ontario" },
                    { 4, "53 Vern st", "Toronto", 6, "metalarm@gmail.com", "Sam", "Wilson", "423-523-1233", "V34 4K6", "Ontario" },
                    { 5, "3 Marvel ct", "Toronto", 3, "mfather01@gmail.com", "Stan", "Lee", "932-032-9234", "VE3 M5A", "Ontario" },
                    { 6, "19 Green ave", "Toronto", 16, "hulk19000@gmail.com", "Bruce", "Banner", "752-922-1211", "S0M A2S", "Ontario" },
                    { 7, "277 Kree dong", "Toronto", 20, "furylover99@gmail.com", "Carol", "Danvers", "989-231-2133", "K1R FU4", "Ontario" },
                    { 8, "6 Web ct", "Quenes", 9, "spidey@gmail.com", "Peter", "Parker", "112-911-9824", "M62 K43", "Ontario" },
                    { 9, "199 Shield ave", "Toronto", 14, "carollover@gmail.com", "Nick", "Fury", "538-423-8421", "A23 F25", "Ontario" },
                    { 10, "1012 Celest st", "Toronto", 15, "starlord23@gmail.com", "Peter", "Quill", "932-244-4423", "A23 F25", "Ontario" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3727), new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3701), "Install fails with error code 410", 10, null, "Could not install" },
                    { 2, 2, new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3731), new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3730), "Program fails with error code 510, unable to open database", 3, null, "Error launching program" },
                    { 3, 3, new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3734), new DateTime(2022, 4, 5, 21, 26, 45, 830, DateTimeKind.Local).AddTicks(3732), "Install fails with error code 410", 4, null, "Could not install" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
