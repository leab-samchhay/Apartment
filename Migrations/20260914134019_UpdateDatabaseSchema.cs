using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
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

            migrationBuilder.RenameColumn(
                name: "dates",
                table: "TblPayslip",
                newName: "date");

            migrationBuilder.AddColumn<string>(
                name: "createby",
                table: "TblPayslip",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdate",
                table: "TblPayslip",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TBLAPPROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(230)", maxLength: 230, nullable: true),
                    ISACTIVE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPPROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPPUSER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    FULLNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PASSWORDHASH = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    ISACTIVE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATEAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPPUSER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPPUSERROLE",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ROLEID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPPUSERROLE", x => new { x.USERID, x.ROLEID });
                    table.ForeignKey(
                        name: "FK_TBLAPPUSERROLE_TBLAPPROLE_ROLEID",
                        column: x => x.ROLEID,
                        principalTable: "TBLAPPROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLAPPUSERROLE_TBLAPPUSER_USERID",
                        column: x => x.USERID,
                        principalTable: "TBLAPPUSER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPPUSER_EMAIL",
                table: "TBLAPPUSER",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPPUSER_USERNAME",
                table: "TBLAPPUSER",
                column: "USERNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPPUSERROLE_ROLEID",
                table: "TBLAPPUSERROLE",
                column: "ROLEID");

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
                name: "TBLAPPUSERROLE");

            migrationBuilder.DropTable(
                name: "TBLAPPROLE");

            migrationBuilder.DropTable(
                name: "TBLAPPUSER");

            migrationBuilder.DropColumn(
                name: "createby",
                table: "TblPayslip");

            migrationBuilder.DropColumn(
                name: "createdate",
                table: "TblPayslip");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "TblPayslip",
                newName: "dates");

            migrationBuilder.AddColumn<decimal>(
                name: "TempId",
                table: "TblBuilding",
                type: "DECIMAL(18, 2)",
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
