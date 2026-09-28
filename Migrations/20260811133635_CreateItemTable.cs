using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.CreateTable(
            //    name: "TblItem",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        ItemName = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
            //        NameKh = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Remark = table.Column<string>(type: "nvarchar2(250)", maxLength: 250, nullable: true),
            //        Status = table.Column<string>(type: "nvarchar2(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblItem", x => x.Id);
            //    });

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
                name: "TblItem");

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
