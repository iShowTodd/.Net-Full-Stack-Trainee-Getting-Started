using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogForeignKey",
                schema: "blogging",
                table: "BlogImages");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_BlogForeignKey",
                schema: "blogging",
                table: "BlogImages");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                schema: "blogging",
                table: "BlogImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Post",
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
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "blogging",
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogId",
                schema: "blogging",
                table: "BlogImages",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId",
                schema: "blogging",
                table: "Post",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                schema: "blogging",
                table: "BlogImages",
                column: "BlogId",
                principalSchema: "blogging",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                schema: "blogging",
                table: "BlogImages");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "blogging");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_BlogId",
                schema: "blogging",
                table: "BlogImages");

            migrationBuilder.DropColumn(
                name: "BlogId",
                schema: "blogging",
                table: "BlogImages");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogForeignKey",
                schema: "blogging",
                table: "BlogImages",
                column: "BlogForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogForeignKey",
                schema: "blogging",
                table: "BlogImages",
                column: "BlogForeignKey",
                principalSchema: "blogging",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
