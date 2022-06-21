using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniNote.Api.Migrations
{
    public partial class SomeUpd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_archived",
                table: "notes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "ix_users_is_deleted",
                table: "users",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_tags_is_deleted",
                table: "tags",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_notes_is_deleted",
                table: "notes",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_groups_is_deleted",
                table: "groups",
                column: "is_deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_is_deleted",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_tags_is_deleted",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_notes_is_deleted",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "ix_groups_is_deleted",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "is_archived",
                table: "notes");
        }
    }
}
