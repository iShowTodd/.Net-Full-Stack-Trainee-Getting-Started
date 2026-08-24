using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "blogging");

            migrationBuilder.DropTable(
                name: "OrderTests",
                schema: "blogging");

            migrationBuilder.DropSequence(
                name: "OrderNumber",
                schema: "blogging");

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "blogging",
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "blogging",
                table: "Blogs",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 2, "https://devblog.io" },
                    { 3, "https://techtalks.net" }
                });

            migrationBuilder.InsertData(
                schema: "blogging",
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Getting started with EF Core.", "EF Core Basics" },
                    { 2, 1, "How migrations work internally.", "Migrations Deep Dive" },
                    { 3, 2, "Best practices for REST APIs.", "REST API Tips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                schema: "blogging",
                table: "Posts",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts",
                schema: "blogging");

            migrationBuilder.DeleteData(
                schema: "blogging",
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "blogging",
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateSequence<int>(
                name: "OrderNumber",
                schema: "blogging");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR blogging.OrderNumber")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTests",
                schema: "blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR blogging.OrderNumber")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTests", x => x.Id);
                });
        }
    }
}
