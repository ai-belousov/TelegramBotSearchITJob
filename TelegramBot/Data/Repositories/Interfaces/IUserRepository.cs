using TelegramBot.Repositories.DTO;

namespace TelegramBot.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<UserDto>> GetByChatId(ulong id);
}