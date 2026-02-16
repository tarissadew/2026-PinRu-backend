using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_PinRu_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDtoToUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Bookings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Bookings",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerName", "RoomName" },
                values: new object[] { null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "IsDeleted", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "Jakarta", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "budi@mail.com", false, "Budi Santoso", "08123456789", "Active" },
                    { 2, "Surabaya", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "siti@mail.com", false, "Siti Aminah", "08223456789", "Active" },
                    { 3, "Bandung", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "andi@mail.com", false, "Andi Wijaya", "08323456789", "Inactive" },
                    { 4, "Medan", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "dewi@mail.com", false, "Dewi Lestari", "08423456789", "Active" },
                    { 5, "Semarang", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "eko@mail.com", false, "Eko Prasetyo", "08523456789", "Active" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
