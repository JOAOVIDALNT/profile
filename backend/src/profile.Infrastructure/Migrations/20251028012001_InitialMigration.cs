using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace profile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ROLES",
                columns: table => new
                {
                    RLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RLE_NAME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RLE_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RLE_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ROLES", x => x.RLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_SUBSCRIBER",
                columns: table => new
                {
                    SUB_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SUB_EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SUB_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SUB_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SUBSCRIBER", x => x.SUB_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    USR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USR_FIRST_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    USR_LAST_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    USR_EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    USR_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    USR_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USR_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERS", x => x.USR_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ARTICLE",
                columns: table => new
                {
                    ART_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ART_TITLE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ART_CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ART_AUTHOR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ART_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ART_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ARTICLE", x => x.ART_ID);
                    table.ForeignKey(
                        name: "FK_TB_ARTICLE_TB_USERS_ART_AUTHOR_ID",
                        column: x => x.ART_AUTHOR_ID,
                        principalTable: "TB_USERS",
                        principalColumn: "USR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_SUBSCRIPTIONS",
                columns: table => new
                {
                    SubscribersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SUBSCRIPTIONS", x => new { x.SubscribersId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_TB_SUBSCRIPTIONS_TB_SUBSCRIBER_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "TB_SUBSCRIBER",
                        principalColumn: "SUB_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_SUBSCRIPTIONS_TB_USERS_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "TB_USERS",
                        principalColumn: "USR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER_ROLES",
                columns: table => new
                {
                    URL_USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL_ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URL_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER_ROLES", x => new { x.URL_USER_ID, x.URL_ROLE_ID });
                    table.ForeignKey(
                        name: "FK_TB_USER_ROLES_TB_ROLES_URL_ROLE_ID",
                        column: x => x.URL_ROLE_ID,
                        principalTable: "TB_ROLES",
                        principalColumn: "RLE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USER_ROLES_TB_USERS_URL_USER_ID",
                        column: x => x.URL_USER_ID,
                        principalTable: "TB_USERS",
                        principalColumn: "USR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARTICLE_ART_AUTHOR_ID",
                table: "TB_ARTICLE",
                column: "ART_AUTHOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ROLES_RLE_NAME",
                table: "TB_ROLES",
                column: "RLE_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_SUBSCRIPTIONS_SubscriptionsId",
                table: "TB_SUBSCRIPTIONS",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_ROLES_URL_ROLE_ID",
                table: "TB_USER_ROLES",
                column: "URL_ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USERS_USR_EMAIL",
                table: "TB_USERS",
                column: "USR_EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ARTICLE");

            migrationBuilder.DropTable(
                name: "TB_SUBSCRIPTIONS");

            migrationBuilder.DropTable(
                name: "TB_USER_ROLES");

            migrationBuilder.DropTable(
                name: "TB_SUBSCRIBER");

            migrationBuilder.DropTable(
                name: "TB_ROLES");

            migrationBuilder.DropTable(
                name: "TB_USERS");
        }
    }
}
