using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Post");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Posts",
                newSchema: "Post");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "Post");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "User",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "User",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Posts",
                schema: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "Post",
                newName: "Comments");
        }
    }
}
