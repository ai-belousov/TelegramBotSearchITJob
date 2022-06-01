namespace TelegramBot.Repositories.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public ulong ChatId { get; set; }
    public string? Email { get; set; }
}