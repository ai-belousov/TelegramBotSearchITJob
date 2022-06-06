using TelegramBot.Repositories.DTO;

namespace TelegramBot.Repositories.Interfaces;

public interface IMenuRepository
{
    public Task<List<MenuDto>> GetAll();

}