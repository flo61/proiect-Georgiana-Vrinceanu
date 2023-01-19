using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObiectiveID",
                table: "Todolist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Obiective",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObiectivulMeu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obiective", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_ObiectiveID",
                table: "Todolist",
                column: "ObiectiveID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Obiective_ObiectiveID",
                table: "Todolist",
                column: "ObiectiveID",
                principalTable: "Obiective",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Obiective_ObiectiveID",
                table: "Todolist");

            migrationBuilder.DropTable(
                name: "Obiective");

            migrationBuilder.DropIndex(
                name: "IX_Todolist_ObiectiveID",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "ObiectiveID",
                table: "Todolist");
        }
    }
}
