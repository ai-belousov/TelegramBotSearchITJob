using AutoMapper;
using TelegramBot.Data;
using TelegramBot.Data.Models;
using TelegramBot.Repositories.Base;
using TelegramBot.Repositories.Interfaces;

namespace TelegramBot.Repositories;

public class BotRepository : BaseRepository
{
    public BotRepository(TelegramBotContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public void GetAll()
    {
        
    }
}