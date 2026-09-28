using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreatePayslipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TblBuilding_TempId",
                table: "TblBuilding");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "TblBuilding");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "TblStaff",
                type: "NVARCHAR2(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "TblGuest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "Varchar2(50)", maxLength: 50, nullable: true),
                    NameKh = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: true),
                    Sex = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar2(20)", maxLength: 20, nullable: true),
                    SSN = table.Column<string>(type: "nvarchar2(20)", maxLength: 20, nullable: true),
                    Passport = table.Column<string>(type: "nvarchar2(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar2(20)", maxLength: 20, nullable: true),
                    Image = table.Column<string>(type: "varchar2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGuest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblPayslip",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dates = table.Column<DateTime>(type: "DATE", nullable: false),
                    staffid = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    salary = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    vat = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    penanty = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    bonus = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    totalsalary = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayslip", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblPayslip_TblStaff_staffid",
                        column: x => x.staffid,
                        principalTable: "TblStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPayslip_staffid",
                table: "TblPayslip",
                column: "staffid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors",
                column: "BuildingId",
                principalTable: "TblBuilding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors");

            migrationBuilder.DropTable(
                name: "TblGuest");

            migrationBuilder.DropTable(
                name: "TblPayslip");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "TblStaff",
                type: "NVARCHAR2(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TempId",
                table: "TblBuilding",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TblBuilding_TempId",
                table: "TblBuilding",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors",
                column: "BuildingId",
                principalTable: "TblBuilding",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
