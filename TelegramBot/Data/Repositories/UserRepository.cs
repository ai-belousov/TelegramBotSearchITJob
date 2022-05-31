using AutoMapper;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;

namespace TelegramBot.Repositories;

public class UserRepository : BaseRepository
{
    public UserRepository(TelegramBotContext context, IMapper mapper) : base(context, mapper)
    {
    }
}