using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersManager.Database.Migrations
{
    public partial class InitOrdersDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Comment", "Mark", "OrderId" },
                values: new object[] { new Guid("2afd95c0-06f6-4a4f-9395-20f17a1e6214"), "Good", 5, new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "ScheduleId" },
                values: new object[] { new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf"), new Guid("e62c8c60-2128-4f50-ae7d-a36876ad2811"), new Guid("11ae77ab-8cbd-407b-bf00-ff761ba9e9f7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
