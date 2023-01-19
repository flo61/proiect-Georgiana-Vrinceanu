using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountriestovisitID",
                table: "Todolist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countriestovisit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countriestovisit", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_CountriestovisitID",
                table: "Todolist",
                column: "CountriestovisitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_Countriestovisit_CountriestovisitID",
                table: "Todolist",
                column: "CountriestovisitID",
                principalTable: "Countriestovisit",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_Countriestovisit_CountriestovisitID",
                table: "Todolist");

            migrationBuilder.DropTable(
                name: "Countriestovisit");

            migrationBuilder.DropIndex(
                name: "IX_Todolist_CountriestovisitID",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "CountriestovisitID",
                table: "Todolist");
        }
    }
}
