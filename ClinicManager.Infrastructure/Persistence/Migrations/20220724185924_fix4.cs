using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Wards_WardId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_WardId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                schema: "dbo",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "TotalBeds",
                schema: "dbo",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "WardId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "WardNumber",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "UnOccupiedBeds",
                schema: "dbo",
                table: "Wards",
                newName: "TotalRooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                schema: "dbo",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Wards_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                schema: "dbo",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Id",
                schema: "dbo",
                table: "Rooms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardId",
                schema: "dbo",
                table: "Rooms",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                schema: "dbo",
                table: "Beds",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Beds_RoomId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "RoomId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "TotalRooms",
                schema: "dbo",
                table: "Wards",
                newName: "UnOccupiedBeds");

            migrationBuilder.AddColumn<int>(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                schema: "dbo",
                table: "Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBeds",
                schema: "dbo",
                table: "Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WardNumber",
                schema: "dbo",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_WardId",
                schema: "dbo",
                table: "Beds",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Wards_WardId",
                schema: "dbo",
                table: "Beds",
                column: "WardId",
                principalSchema: "dbo",
                principalTable: "Wards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
