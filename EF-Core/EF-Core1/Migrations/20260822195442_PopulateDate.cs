using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core1.Migrations
{
    /// <inheritdoc />
    public partial class PopulateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Employees values('Ahmed')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees WHERE Name = 'Ahmed'");
        }
    }
}
