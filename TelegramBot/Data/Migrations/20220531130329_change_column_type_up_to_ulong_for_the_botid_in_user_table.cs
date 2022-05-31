using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Migrations
{
    public partial class change_column_type_up_to_ulong_for_the_botid_in_user_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "user_bot_id",
                table: "user",
                type: "numeric(20,0)",
                nullable: false,
                comment: "Пользователи телеграм",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Пользователи телеграм");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "user_bot_id",
                table: "user",
                type: "integer",
                nullable: false,
                comment: "Пользователи телеграм",
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)",
                oldComment: "Пользователи телеграм");
        }
    }
}
