using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace profile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionRefac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SubscribersId",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_USERS_SubscriptionsId",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.RenameColumn(
                name: "SubscriptionsId",
                table: "TB_SUBSCRIPTIONS",
                newName: "SUBS_SUBSCRIBER_ID");

            migrationBuilder.RenameColumn(
                name: "SubscribersId",
                table: "TB_SUBSCRIPTIONS",
                newName: "SUBS_AUTHOR_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_SUBSCRIPTIONS_SubscriptionsId",
                table: "TB_SUBSCRIPTIONS",
                newName: "IX_TB_SUBSCRIPTIONS_SUBS_SUBSCRIBER_ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "SUBS_CREATED_AT",
                table: "TB_SUBSCRIPTIONS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SUBS_UPDATED_AT",
                table: "TB_SUBSCRIPTIONS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS",
                column: "SUBS_SUBSCRIBER_ID",
                principalTable: "TB_SUBSCRIBER",
                principalColumn: "SUB_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_USERS_SUBS_AUTHOR_ID",
                table: "TB_SUBSCRIPTIONS",
                column: "SUBS_AUTHOR_ID",
                principalTable: "TB_USERS",
                principalColumn: "USR_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_USERS_SUBS_AUTHOR_ID",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropColumn(
                name: "SUBS_CREATED_AT",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropColumn(
                name: "SUBS_UPDATED_AT",
                table: "TB_SUBSCRIPTIONS");

            migrationBuilder.RenameColumn(
                name: "SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS",
                newName: "SubscriptionsId");

            migrationBuilder.RenameColumn(
                name: "SUBS_AUTHOR_ID",
                table: "TB_SUBSCRIPTIONS",
                newName: "SubscribersId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_SUBSCRIPTIONS_SUBS_SUBSCRIBER_ID",
                table: "TB_SUBSCRIPTIONS",
                newName: "IX_TB_SUBSCRIPTIONS_SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SubscribersId",
                table: "TB_SUBSCRIPTIONS",
                column: "SubscribersId",
                principalTable: "TB_SUBSCRIBER",
                principalColumn: "SUB_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SUBSCRIPTIONS_TB_USERS_SubscriptionsId",
                table: "TB_SUBSCRIPTIONS",
                column: "SubscriptionsId",
                principalTable: "TB_USERS",
                principalColumn: "USR_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
