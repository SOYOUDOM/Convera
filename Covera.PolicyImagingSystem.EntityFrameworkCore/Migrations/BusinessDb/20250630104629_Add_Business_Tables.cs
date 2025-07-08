using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covera.PolicyImagingSystem.EntityFrameworkCore.Migrations.BusinessDb
{
    /// <inheritdoc />
    public partial class Add_Business_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "C360");

            migrationBuilder.CreateTable(
                name: "LifeAssured",
                schema: "C360",
                columns: table => new
                {
                    PolicyNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LifeAssuredNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PolicyOwnerFlag = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LifeAssuredSequence = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ClientAddress1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientAddress2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientAddress3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientAddress4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientAddress5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeAssured", x => x.PolicyNumber);
                });

            migrationBuilder.CreateTable(
                name: "PolicyHeader",
                schema: "C360",
                columns: table => new
                {
                    PolicyNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PolicyOwnerNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BillFrequencyDescription = table.Column<int>(type: "int", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlanCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PlanNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LifeAssured = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHeader", x => x.PolicyNumber);
                });

            migrationBuilder.CreateTable(
                name: "PolicyOwner",
                schema: "C360",
                columns: table => new
                {
                    PolicyOwnerNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerAge = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ClientAddress1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientAddress2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientAddress3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientAddress4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientAddress5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyOwner", x => x.PolicyOwnerNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LifeAssured",
                schema: "C360");

            migrationBuilder.DropTable(
                name: "PolicyHeader",
                schema: "C360");

            migrationBuilder.DropTable(
                name: "PolicyOwner",
                schema: "C360");
        }
    }
}
