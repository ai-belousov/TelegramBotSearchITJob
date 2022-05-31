using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Migrations
{
    public partial class add_column_telegram_bot_token_to_bot_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "telegram_bot_token",
                table: "bot",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Token телеграм бота");

            migrationBuilder.UpdateData(
                table: "bot",
                keyColumn: "id",
                keyValue: 1,
                column: "telegram_bot_token",
                value: "AAHgamcmzMRG1M39RFvGPglgXKxuD44lGd8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "telegram_bot_token",
                table: "bot");
        }
    }
}
