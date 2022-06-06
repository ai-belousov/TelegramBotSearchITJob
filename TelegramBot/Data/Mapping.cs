using AutoMapper;
using TelegramBot.Data.Entities;
using TelegramBot.Repositories.DTO;

namespace TelegramBot.Data;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Bot, BotDto>();
        CreateMap<User, UserDto>();
        CreateMap<Menu, MenuDto>();
        CreateMap<UserSettings, UserSettingsDto>();
        CreateMap<TypeMenu, TypeMenuDto>();
    }
}