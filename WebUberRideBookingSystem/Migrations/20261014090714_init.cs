using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUberRideBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropOffLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rides_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rides_Users_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_rides_RiderId",
                        column: x => x.RiderId,
                        principalTable: "rides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rating_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DriverId", "Email", "FullName", "Password", "RiderId", "Role", "phonenumber" },
                values: new object[] { 1, 1, "Ro@gmail.com", "Rofaida Hamada", "Ro@1233", 1, "Vehicle", "01005620" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "DriverId", "PlateNumber", "color" },
                values: new object[] { 1, 1, "245sqs", "red" });

            migrationBuilder.InsertData(
                table: "rides",
                columns: new[] { "Id", "DriverId", "DropOffLocation", "Fare", "PickupLocation", "RiderId", "Status" },
                values: new object[] { 1, 1, "jddldkjqwldwq", 1263, "jegdewfgkeuj", 1, "Pegane" });

            migrationBuilder.CreateIndex(
                name: "IX_payment_RiderId",
                table: "payment",
                column: "RiderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rating_RideId",
                table: "rating",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rides_DriverId",
                table: "rides",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_rides_RiderId",
                table: "rides",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "rides");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
