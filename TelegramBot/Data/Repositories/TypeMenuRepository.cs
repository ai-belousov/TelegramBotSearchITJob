using AutoMapper;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;

namespace TelegramBot.Repositories;

public class TypeMenuRepository : BaseRepository
{
    public TypeMenuRepository(TelegramBotContext context, IMapper mapper) : base(context, mapper)
    {
    }
}