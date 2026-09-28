using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APARTMENT_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRoomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.CreateTable(
            //    name: "TblRoomType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        RoomTypeName = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
            //        RoomTypeNameKh = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblRoomType", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "TblFloor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BuildingTypeId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    BuildingId = table.Column<decimal>(type: "number", nullable: false),
                    FloorNo = table.Column<byte>(type: "number(3)", nullable: false)
                });
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_TblFloor", x => x.Id);
                //    table.ForeignKey(
                //        name: "FK_TblFloor_TblBuilding_BuildingTypeId",
                //        column: x => x.BuildingTypeId,
                //        principalTable: "TblBuilding",
                //        principalColumn: "Id");
                //});

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblFloor_BuildingTypeId",
            //    table: "TblFloor",
            //    column: "BuildingTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TblFloors_TblBuilding_BuildingId",
            //    table: "TblFloors",
            //    column: "BuildingId",
            //    principalTable: "TblBuilding",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
