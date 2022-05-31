using AutoMapper;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;

namespace TelegramBot.Repositories;

public class UserSettingsRepository : BaseRepository
{
    public UserSettingsRepository(TelegramBotContext context, IMapper mapper) : base(context, mapper)
    {
    }
}