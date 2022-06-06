using TelegramBot.Data.Entities;

namespace TelegramBot.Repositories.Interfaces;

public interface IBotRepository
{
    public Task<List<Bot>> GetAllBots();
}