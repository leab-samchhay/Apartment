using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateSalaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TblFloors_TblBuilding_BuildingId",
            //    table: "TblFloors");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_TblBuilding_TempId",
            //    table: "TblBuilding");

            //migrationBuilder.DropColumn(
            //    name: "TempId",
            //    table: "TblBuilding");

            migrationBuilder.CreateTable(
                name: "TblSalary",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    staffid = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    date = table.Column<DateTime>(type: "DATE", nullable: false),
                    salary = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    note = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    createdate = table.Column<DateTime>(type: "DATE", nullable: false),
                    createby = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSalary", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblSalary_TblStaff_staffid",
                        column: x => x.staffid,
                        principalTable: "TblStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSalary_staffid",
                table: "TblSalary",
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
                name: "TblSalary");

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
