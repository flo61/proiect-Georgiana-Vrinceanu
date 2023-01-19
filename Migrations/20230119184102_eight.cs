using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterieID",
                table: "Todolist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materiipecaresaleiau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_MaterieID",
                table: "Todolist",
                column: "MaterieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Materie_MaterieID",
                table: "Todolist",
                column: "MaterieID",
                principalTable: "Materie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Materie_MaterieID",
                table: "Todolist");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropIndex(
                name: "IX_Todolist_MaterieID",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "MaterieID",
                table: "Todolist");
        }
    }
}
