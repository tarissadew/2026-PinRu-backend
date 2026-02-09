using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_PinRu_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialFullSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
