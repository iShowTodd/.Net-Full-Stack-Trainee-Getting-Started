using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogUrl",
                schema: "blogging",
                table: "Blogs",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "blogging",
                table: "Blogs",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "blogging",
                table: "Blogs",
                newName: "BlogUrl");

            migrationBuilder.AlterColumn<string>(
                name: "BlogUrl",
                schema: "blogging",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
