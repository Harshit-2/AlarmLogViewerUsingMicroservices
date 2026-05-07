using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperatureLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    ReadingId = table.Column<string>(type: "CHAR(6)", nullable: false),
                    RoomId = table.Column<string>(type: "CHAR(6)", nullable: false),
                    TemperatureValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecordedAt = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.ReadingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatures");
        }
    }
}
