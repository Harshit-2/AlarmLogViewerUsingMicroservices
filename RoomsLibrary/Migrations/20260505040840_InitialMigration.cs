using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomsLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "CHAR(6)", nullable: false),
                    RoomName = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    MinTemp = table.Column<int>(type: "int", nullable: false),
                    MaxTemp = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "CHAR(6)", nullable: false),
                    CreatedAt = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
