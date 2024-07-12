using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRecruitment.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Jobs",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Jobs",
                newName: "WorkMode");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employer",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryType",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescriptions",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeySkills",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Openings",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Employer",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IndustryType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobDescriptions",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "KeySkills",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Openings",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "WorkMode",
                table: "Jobs",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Jobs",
                newName: "UserId");
        }
    }
}
