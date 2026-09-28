using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFloors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblFloors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FloorNo = table.Column<byte>(type: "number(3)", nullable: false),
                    BuildingId = table.Column<decimal>(type: "number", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFloors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblFloors_TblBuilding_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "TblBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblFloors_BuildingId",
                table: "TblFloors",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblFloors");
        }
    }
}
