using AutoMapper;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;

namespace TelegramBot.Repositories;

public class MenuRepository : BaseRepository
{
    public MenuRepository(TelegramBotContext context, IMapper mapper) : base(context, mapper)
    {
    }
}