using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace profile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetPluralSubscriberTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_SUBSCRIBER",
                table: "TB_SUBSCRIBER");

            migrationBuilder.RenameTable(
                name: "TB_SUBSCRIBER",
                newName: "TB_SUBSCRIBERS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_SUBSCRIBERS",
                table: "TB_SUBSCRIBERS",
                column: "SUB_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBERS_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS",
                column: "SUBS_SUBSCRIBER_ID",
                principalTable: "TB_SUBSCRIBERS",
                principalColumn: "SUB_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBERS_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_SUBSCRIBERS",
                table: "TB_SUBSCRIBERS");

            migrationBuilder.RenameTable(
                name: "TB_SUBSCRIBERS",
                newName: "TB_SUBSCRIBER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_SUBSCRIBER",
                table: "TB_SUBSCRIBER",
                column: "SUB_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS",
                column: "SUBS_SUBSCRIBER_ID",
                principalTable: "TB_SUBSCRIBER",
                principalColumn: "SUB_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
