using AutoMapper;
using TelegramBot.Data.Models;
using TelegramBot.Repositories.DTO;
using User = Telegram.Bot.Types.User;

namespace TelegramBot.Data;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Bot, BotDto>();
        CreateMap<User, UserDto>();
        CreateMap<UserSettings, UserSettingsDto>();
        CreateMap<TypeMenu, TypeMenuDto>();
    }
}