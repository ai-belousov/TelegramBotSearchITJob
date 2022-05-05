namespace TelegramBot.DataBase.Models;

public class User
{
    public int Id { get; set; }
    public int BotUserId { get; set; }
    public string? Email { get; set; }
}