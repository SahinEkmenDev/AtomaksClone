using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtomaksClone.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionToİcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Questions");
        }
    }
}
