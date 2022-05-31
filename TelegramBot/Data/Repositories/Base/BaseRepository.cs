using AutoMapper;
using TelegramBot.Data;

namespace TelegramBot.Repositories.Base;

public class BaseRepository 
{
    protected readonly TelegramBotContext Bd;
    protected readonly IMapper Mapper;

    public BaseRepository(TelegramBotContext context, IMapper mapper)
    {
        Bd = context;
        Mapper = mapper;
    }
}