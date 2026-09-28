using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TblFloors_TblBuilding_BuildingId",
            //    table: "TblFloors");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_TblortherExpens_ExpensType_ExpensTypeId",
            //    table: "TblortherExpens");

            //migrationBuilder.DropIndex(
            //    name: "IX_TblortherExpens_ExpensTypeId",
            //    table: "TblortherExpens");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_TblBuilding_TempId",
            //    table: "TblBuilding");

            //migrationBuilder.DropColumn(
            //    name: "ExpensTypeId",
            //    table: "TblortherExpens");

            //migrationBuilder.DropColumn(
            //    name: "TempId",
            //    table: "TblBuilding");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblortherExpens_ExpenseTypeId",
            //    table: "TblortherExpens",
            //    column: "ExpenseTypeId");

            // 👇 Commented out to fix ORA-02275
            // migrationBuilder.AddForeignKey(
            //     name: "FK_TblFloors_TblBuilding_BuildingId",
            //     table: "TblFloors",
            //     column: "BuildingId",
            //     principalTable: "TblBuilding",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TblortherExpens_ExpensType_ExpenseTypeId",
            //    table: "TblortherExpens",
            //    column: "ExpenseTypeId",
            //    principalTable: "ExpensType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors");

            migrationBuilder.DropForeignKey(
                name: "FK_TblortherExpens_ExpensType_ExpenseTypeId",
                table: "TblortherExpens");

            migrationBuilder.DropIndex(
                name: "IX_TblortherExpens_ExpenseTypeId",
                table: "TblortherExpens");

            migrationBuilder.AddColumn<int>(
                name: "ExpensTypeId",
                table: "TblortherExpens",
                type: "NUMBER(10)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TblortherExpens_ExpensTypeId",
                table: "TblortherExpens",
                column: "ExpensTypeId");

            // 👇 Uncommented to allow proper rollback
            migrationBuilder.AddForeignKey(
                name: "FK_TblFloors_TblBuilding_BuildingId",
                table: "TblFloors",
                column: "BuildingId",
                principalTable: "TblBuilding",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblortherExpens_ExpensType_ExpensTypeId",
                table: "TblortherExpens",
                column: "ExpensTypeId",
                principalTable: "ExpensType",
                principalColumn: "Id");
        }
    }
}