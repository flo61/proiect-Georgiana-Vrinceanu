using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class nine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Whocansee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whocansee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incredere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhocanseeID = table.Column<int>(type: "int", nullable: true),
                    TodolistID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incredere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Incredere_Todolist_TodolistID",
                        column: x => x.TodolistID,
                        principalTable: "Todolist",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Incredere_Whocansee_WhocanseeID",
                        column: x => x.WhocanseeID,
                        principalTable: "Whocansee",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incredere_TodolistID",
                table: "Incredere",
                column: "TodolistID");

            migrationBuilder.CreateIndex(
                name: "IX_Incredere_WhocanseeID",
                table: "Incredere",
                column: "WhocanseeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incredere");

            migrationBuilder.DropTable(
                name: "Whocansee");
        }
    }
}
