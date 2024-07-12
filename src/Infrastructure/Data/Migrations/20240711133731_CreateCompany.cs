using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRecruitment.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoofEmployee = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTelephone = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
