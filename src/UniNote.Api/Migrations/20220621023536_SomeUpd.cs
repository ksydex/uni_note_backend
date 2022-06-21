using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniNote.Api.Migrations
{
    public partial class SomeUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "created_by_user_id",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "notes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_tags_created_by_user_id",
                table: "tags",
                column: "created_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_users_created_by_user_id",
                table: "tags",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_users_created_by_user_id",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_created_by_user_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "name",
                table: "notes");
        }
    }
}
