using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBAPI.Migrations
{
    public partial class addingUserCharactertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCharacters",
                columns: table => new
                {
                    UserCharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterType = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CharacterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(900)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharacters", x => x.UserCharacterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCharacters");
        }
    }
}
