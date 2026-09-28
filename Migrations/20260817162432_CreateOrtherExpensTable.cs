using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrtherExpensTable : Migration
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

            //migrationBuilder.AlterColumn<string>(
            //    name: "positionNameKh",
            //    table: "TblPosition",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar2(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.AlterColumn<string>(
            //    name: "positionName",
            //    table: "TblPosition",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar2(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.CreateTable(
            //    name: "TblortherExpens",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        DateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
            //        ExpenseTypeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
            //        ExpensTypeId = table.Column<int>(type: "NUMBER(10)", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Note = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
            //        Image = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblortherExpens", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TblortherExpens_ExpensType_ExpensTypeId",
            //            column: x => x.ExpensTypeId,
            //            principalTable: "ExpensType",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblortherExpens_ExpensTypeId",
            //    table: "TblortherExpens",
            //    column: "ExpensTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TblFloors_TblBuilding_BuildingId",
            //    table: "TblFloors",
            //    column: "BuildingId",
            //    principalTable: "TblBuilding",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors");

            migrationBuilder.DropTable(
                name: "TblortherExpens");

            migrationBuilder.AlterColumn<string>(
                name: "positionNameKh",
                table: "TblPosition",
                type: "nvarchar2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "positionName",
                table: "TblPosition",
                type: "nvarchar2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
