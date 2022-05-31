namespace TelegramBot.Repositories.DTO;

public class MenuDto
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int TypeMenuId { get; set; }
    public int BotId { get; set; }
}