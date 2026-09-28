using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateStaffTable : Migration
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
                name: "TblStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    positionId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    nameKh = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    sex = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    dob = table.Column<DateTime>(type: "DATE", nullable: false),
                    phone = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    identityNo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    photo = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    createAt = table.Column<DateTime>(type: "DATE", nullable: false),
                    createBy = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblStaff_TblPosition_positionId",
                        column: x => x.positionId,
                        principalTable: "TblPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblStaff_positionId",
                table: "TblStaff",
                column: "positionId");

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
                name: "TblStaff");

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
