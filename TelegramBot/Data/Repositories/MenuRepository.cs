using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;
using TelegramBot.Repositories.DTO;
using TelegramBot.Repositories.Interfaces;

namespace TelegramBot.Repositories;

public class MenuRepository : BaseRepository, IMenuRepository
{
    public MenuRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public async Task<List<MenuDto>> GetAll()
    {
        var menus = await Db.Menus.ToListAsync();
        return menus.Select(m => Mapper.Map<MenuDto>(m)).ToList();
    }
}