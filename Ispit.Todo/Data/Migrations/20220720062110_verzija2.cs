using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class verzija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoListViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoListViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoListViewModel_ApplicationUserViewModel_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUserViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                column: "ConcurrencyStamp",
                value: "2f8da28a-cb49-4ee2-8bd9-4a50a8016f7f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6fceb22-4bd0-45af-91f0-3c349ea9b471", "AQAAAAEAACcQAAAAEHpVaMxH7fAKHhREF379P2Qcu+lYa6scNajmOVfiod7yteph6mv8diV8evoe3+1nUg==" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoListViewModel_UserId",
                table: "TodoListViewModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoListViewModel");

            migrationBuilder.DropTable(
                name: "ApplicationUserViewModel");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                column: "ConcurrencyStamp",
                value: "bd3edb45-b727-43b4-8e77-92dfcf543548");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7b7b1c2-f2f2-4f6f-8c98-42bf99b63be7", "AQAAAAEAACcQAAAAEDLGonYc/cZkfHs/8yy3F0FyuZ1VGQc433Tq99/8ztiSnWILCDCmwuaIbARGo/YB4g==" });
        }
    }
}
