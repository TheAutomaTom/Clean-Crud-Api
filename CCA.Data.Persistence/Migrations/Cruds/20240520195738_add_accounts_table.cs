using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCA.Data.Persistence.Migrations.Cruds
{
    /// <inheritdoc />
    public partial class add_accounts_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Cruds",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.InsertData(
                table: "Cruds",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Department", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { -10, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8607), "Home & Jewelery", null, null, "Unbranded Granite Fish" },
                    { -9, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8581), "Games", null, null, "Unbranded Concrete Chair" },
                    { -8, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8546), "Kids & Industrial", null, null, "Awesome Soft Keyboard" },
                    { -7, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8515), "Electronics", null, null, "Licensed Plastic Chicken" },
                    { -6, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8429), "Health & Computers", null, null, "Practical Plastic Gloves" },
                    { -5, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8391), "Movies & Jewelery", null, null, "Incredible Soft Car" },
                    { -4, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8331), "Music, Health & Beauty", null, null, "Refined Soft Soap" },
                    { -3, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8300), "Health", null, null, "Practical Granite Pants" },
                    { -2, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8213), "Books & Industrial", null, null, "Handcrafted Rubber Cheese" },
                    { -1, "", new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(7866), "Industrial", null, null, "Handcrafted Cotton Chips" }
                });
        }
    }
}
