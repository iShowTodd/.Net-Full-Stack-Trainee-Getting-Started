using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Books", schema: "blogging");

            migrationBuilder.DropTable(name: "Posts", schema: "blogging");

            migrationBuilder.DropColumn(name: "AddedOn", schema: "blogging", table: "Blogs");

            migrationBuilder.DropColumn(name: "Rating", schema: "blogging", table: "Blogs");

            migrationBuilder.CreateTable(
                name: "BlogImages",
                schema: "blogging",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(
                        type: "nvarchar(250)",
                        maxLength: 250,
                        nullable: false
                    ),
                    BlogForeignKey = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogImages_Blogs_BlogForeignKey",
                        column: x => x.BlogForeignKey,
                        principalSchema: "blogging",
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogForeignKey",
                schema: "blogging",
                table: "BlogImages",
                column: "BlogForeignKey",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BlogImages", schema: "blogging");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                schema: "blogging",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()"
            );

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                schema: "blogging",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 2
            );

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "blogging",
                columns: table => new
                {
                    BookKey = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("BookId", x => x.BookKey);
                }
            );

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "blogging",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                schema: "blogging",
                table: "Posts",
                column: "BlogId"
            );
        }
    }
}
