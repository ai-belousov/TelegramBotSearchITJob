namespace TelegramBot.Repositories.DTO;

public class BotDto
{
    public int Id { get; set; }
    public long TelegramBotId { get; set; }
    public string Name { get; set; }
    public string TelegramBotToken { get; set; }
}