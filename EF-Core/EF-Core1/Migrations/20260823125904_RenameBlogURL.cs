using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class RenameBlogURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "blogging",
                table: "Blogs",
                newName: "BlogURL");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                schema: "blogging",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedOn",
                schema: "blogging",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogURL",
                schema: "blogging",
                table: "Blogs",
                newName: "Url");
        }
    }
}
