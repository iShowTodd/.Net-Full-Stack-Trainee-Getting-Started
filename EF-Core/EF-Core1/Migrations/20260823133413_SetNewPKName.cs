using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class SetNewPKName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "blogging",
                table: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "BookId",
                schema: "blogging",
                table: "Books",
                column: "BookKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "BookId",
                schema: "blogging",
                table: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "blogging",
                table: "Books",
                column: "BookKey");
        }
    }
}
