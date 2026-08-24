using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Blogs_BlogId",
                schema: "blogging",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                schema: "blogging",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "blogging",
                newName: "Posts",
                newSchema: "blogging");

            migrationBuilder.RenameIndex(
                name: "IX_Post_BlogId",
                schema: "blogging",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "blogging",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                schema: "blogging",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTageTest",
                schema: "blogging",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTageTest", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTageTest_Posts_PostsId",
                        column: x => x.PostsId,
                        principalSchema: "blogging",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTageTest_Tags_TagsId",
                        column: x => x.TagsId,
                        principalSchema: "blogging",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTageTest_TagsId",
                schema: "blogging",
                table: "PostTageTest",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                schema: "blogging",
                table: "Posts",
                column: "BlogId",
                principalSchema: "blogging",
                principalTable: "Blogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                schema: "blogging",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostTageTest",
                schema: "blogging");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "blogging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                schema: "blogging",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                schema: "blogging",
                newName: "Post",
                newSchema: "blogging");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                schema: "blogging",
                table: "Post",
                newName: "IX_Post_BlogId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                schema: "blogging",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                schema: "blogging",
                table: "Post",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Blogs_BlogId",
                schema: "blogging",
                table: "Post",
                column: "BlogId",
                principalSchema: "blogging",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
