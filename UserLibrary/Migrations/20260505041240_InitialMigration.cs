using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "CHAR(6)", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    CreatedAt = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
