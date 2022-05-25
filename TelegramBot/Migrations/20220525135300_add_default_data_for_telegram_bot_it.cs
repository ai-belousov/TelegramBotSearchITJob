using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Migrations
{
    public partial class add_default_data_for_telegram_bot_it : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "bot",
                columns: new[] { "id", "name", "telegram_bot_id" },
                values: new object[] { 1, "Поиск IT-вакансий", 5179375578L });

            migrationBuilder.InsertData(
                table: "type_menu",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Специальность" },
                    { 2, "Формат работы" },
                    { 3, "Зарплата" }
                });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "id", "bot_id", "type_menu_id", "value" },
                values: new object[,]
                {
                    { 1, 1, 1, "Java/Scala" },
                    { 2, 1, 1, "Python" },
                    { 3, 1, 1, "C#" },
                    { 4, 1, 1, "C/C++" },
                    { 5, 1, 1, "Go" },
                    { 6, 1, 1, "Ruby" },
                    { 7, 1, 1, "PHP" },
                    { 8, 1, 1, "Frontend" },
                    { 9, 1, 1, "Node.js" },
                    { 10, 1, 1, "DevOps" },
                    { 11, 1, 1, "QA Manual" },
                    { 12, 1, 1, "QA Auto" },
                    { 13, 1, 1, "Data Scientist" },
                    { 14, 1, 1, "Product Manager" },
                    { 15, 1, 1, "Product Analyst" },
                    { 16, 1, 1, "Project Manager" },
                    { 17, 1, 1, "CTO / Architect" },
                    { 18, 1, 1, "Design & UX" },
                    { 19, 1, 1, "System Analyst" },
                    { 20, 1, 1, "IT HR / Recruiter" },
                    { 21, 1, 2, "Москва (гибрад или офис)" },
                    { 22, 1, 2, "Санкт-Петербург (гибрад или офис)" },
                    { 23, 1, 2, "Полная удаленка" },
                    { 24, 1, 2, "Релокейт за рубеж" },
                    { 25, 1, 3, "от 150К ₽/мес" },
                    { 26, 1, 3, "от 200К ₽/мес" },
                    { 27, 1, 3, "от 250К ₽/мес" },
                    { 28, 1, 3, "от 350К ₽/мес" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "bot",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "type_menu",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "type_menu",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "type_menu",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
