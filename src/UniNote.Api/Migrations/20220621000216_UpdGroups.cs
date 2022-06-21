using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniNote.Api.Migrations
{
    public partial class UpdGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "groups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_groups_group_id",
                table: "groups",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "fk_groups_groups_group_id",
                table: "groups",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_groups_groups_group_id",
                table: "groups");

            migrationBuilder.DropIndex(
                name: "ix_groups_group_id",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "groups");
        }
    }
}
