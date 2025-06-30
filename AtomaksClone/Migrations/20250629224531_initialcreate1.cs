using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtomaksClone.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Answers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Answers");
        }
    }
}
