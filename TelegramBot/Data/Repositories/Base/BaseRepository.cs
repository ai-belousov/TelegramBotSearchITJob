using AutoMapper;
using TelegramBot.Data;

namespace TelegramBot.Repositories.Base;

public class BaseRepository 
{
    protected readonly Context Db;
    protected readonly IMapper Mapper;

    public BaseRepository(Context context, IMapper mapper)
    {
        Db = context;
        Mapper = mapper;
    }
}