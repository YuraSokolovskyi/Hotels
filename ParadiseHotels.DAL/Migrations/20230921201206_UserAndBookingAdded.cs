using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParadiseHotels.DAL.Migrations
{
    public partial class UserAndBookingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomsStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RoomsStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomsStatuses_RoomId",
                table: "RoomsStatuses",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsStatuses_UserId",
                table: "RoomsStatuses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsStatuses_Rooms_RoomId",
                table: "RoomsStatuses",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsStatuses_Users_UserId",
                table: "RoomsStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsStatuses_Rooms_RoomId",
                table: "RoomsStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsStatuses_Users_UserId",
                table: "RoomsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_RoomsStatuses_RoomId",
                table: "RoomsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_RoomsStatuses_UserId",
                table: "RoomsStatuses");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomsStatuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomsStatuses");
        }
    }
}
