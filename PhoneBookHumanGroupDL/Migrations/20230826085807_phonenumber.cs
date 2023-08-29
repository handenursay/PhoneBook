using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookHumanGroupDL.Migrations
{
    /// <inheritdoc />
    public partial class phonenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "MEMBERPHONE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "MEMBERPHONE");
        }
    }
}
