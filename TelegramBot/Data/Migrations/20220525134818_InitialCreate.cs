using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TelegramBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bot",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telegram_bot_id = table.Column<long>(type: "bigint", nullable: false, comment: "id телеграм бота"),
                    name = table.Column<string>(type: "text", nullable: true, comment: "Название бота")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot", x => x.id);
                },
                comment: "Телеграм боты");

            migrationBuilder.CreateTable(
                name: "type_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true, comment: "Тип меню")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_menu", x => x.id);
                },
                comment: "Типы меню");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nickname = table.Column<string>(type: "text", nullable: false, comment: "Ник пользователя"),
                    user_bot_id = table.Column<int>(type: "integer", nullable: false, comment: "Пользователи телеграм"),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Почта пользователя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                },
                comment: "Пользователи");

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: false, comment: "Значение кнопки меню"),
                    type_menu_id = table.Column<int>(type: "integer", nullable: false, comment: "id типа меню"),
                    bot_id = table.Column<int>(type: "integer", nullable: false, comment: "id бота")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_bot_bot_id",
                        column: x => x.bot_id,
                        principalTable: "bot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_type_menu_type_menu_id",
                        column: x => x.type_menu_id,
                        principalTable: "type_menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Меню(кнопки выбора) бота");

            migrationBuilder.CreateTable(
                name: "user_settings",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    menu_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата создания")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_settings", x => new { x.menu_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_user_settings_menu_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_settings_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Настройки пользователей");

            migrationBuilder.CreateIndex(
                name: "IX_menu_bot_id",
                table: "menu",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_type_menu_id",
                table: "menu",
                column: "type_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_settings_user_id",
                table: "user_settings",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_settings");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "bot");

            migrationBuilder.DropTable(
                name: "type_menu");
        }
    }
}
