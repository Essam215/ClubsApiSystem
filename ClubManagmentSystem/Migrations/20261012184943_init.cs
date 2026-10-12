using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClubManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HourlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    GroupSize = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "memberShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_memberShips_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberShipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_memberShips_MemberShipId",
                        column: x => x.MemberShipId,
                        principalTable: "memberShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "facilities",
                columns: new[] { "Id", "Capacity", "HourlyPrice", "Name" },
                values: new object[,]
                {
                    { 1, 30, 250m, "Swimming Pool" },
                    { 2, 40, 150m, "Gym Hall" },
                    { 3, 10, 200m, "Tennis Court" }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Mohamed", "01011112222" },
                    { 2, new DateTime(1998, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona@example.com", "Mona Ali", "01022223333" },
                    { 3, new DateTime(2002, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@example.com", "Omar Hassan", "01033334444" }
                });

            migrationBuilder.InsertData(
                table: "bookings",
                columns: new[] { "Id", "BookingDate", "EndTime", "FacilityId", "GroupSize", "MemberId", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 1, 10, 1, new TimeSpan(0, 10, 0, 0, 0), "Confirmed" },
                    { 2, new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), 2, 8, 2, new TimeSpan(0, 14, 0, 0, 0), "Confirmed" },
                    { 3, new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 3, 4, 3, new TimeSpan(0, 16, 0, 0, 0), "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "memberShips",
                columns: new[] { "Id", "EndDate", "MemberId", "Price", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5000m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Gold" },
                    { 2, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3000m, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Silver" },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1500m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expired", "Basic" }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "Id", "Amount", "MemberShipId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 5000m, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 2, 3000m, 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 3, 1500m, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_FacilityId",
                table: "bookings",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_MemberId",
                table: "bookings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_facilities_Name",
                table: "facilities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_memberShips_MemberId",
                table: "memberShips",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_MemberShipId",
                table: "payments",
                column: "MemberShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "memberShips");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
