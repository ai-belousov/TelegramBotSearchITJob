using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TelegramBot.Data;
using TelegramBot.Data.Entities;
using TelegramBot.Repositories.Base;
using TelegramBot.Repositories.DTO;
using TelegramBot.Repositories.Interfaces;


namespace TelegramBot.Repositories;

public class BotRepository : BaseRepository, IBotRepository
{
    public BotRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
    public async Task<List<Bot>> GetAllBots()
    {
        var bots = await Db.Bots.ToListAsync();
        return bots.Select(b => Mapper.Map<Bot>(b)).ToList();
    }
}