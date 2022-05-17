namespace TelegramBot.DataBase.Models;

public class Menu
{
    public int Id { get; set; }
    public int TypeMenuId { get; set; }
    public string Name { get; set; }
    public int BotId { get; set; }
}