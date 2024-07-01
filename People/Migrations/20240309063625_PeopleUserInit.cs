using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace People.Migrations
{
    /// <inheritdoc />
    public partial class PeopleUserInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MdlPeopleApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Genter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StZip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdlPeopleApp", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MdlPeopleApp");
        }
    }
}
