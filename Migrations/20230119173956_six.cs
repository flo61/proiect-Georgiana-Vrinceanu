using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarteID",
                table: "Todolist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCarte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carte", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_CarteID",
                table: "Todolist",
                column: "CarteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Carte_CarteID",
                table: "Todolist",
                column: "CarteID",
                principalTable: "Carte",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Carte_CarteID",
                table: "Todolist");

            migrationBuilder.DropTable(
                name: "Carte");

            migrationBuilder.DropIndex(
                name: "IX_Todolist_CarteID",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "CarteID",
                table: "Todolist");
        }
    }
}
