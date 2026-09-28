using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateExpensTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.CreateTable(
            //    name: "ExpensType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        expensType = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ExpensType", x => x.Id);
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

            migrationBuilder.DropTable(
                name: "ExpensType");

            
        }
    }
}
