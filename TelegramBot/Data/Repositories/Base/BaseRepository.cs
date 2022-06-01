using AutoMapper;
using TelegramBot.Data;

namespace TelegramBot.Repositories.Base;

public class BaseRepository 
{
    protected readonly TelegramBotContext Db;
    protected readonly IMapper Mapper;

    public BaseRepository(TelegramBotContext context, IMapper mapper)
    {
        Db = context;
        Mapper = mapper;
    }
}