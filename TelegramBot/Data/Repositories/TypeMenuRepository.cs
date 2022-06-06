using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;
using TelegramBot.Repositories.DTO;

namespace TelegramBot.Repositories;

public class TypeMenuRepository : BaseRepository
{
    public TypeMenuRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
    public async Task<List<TypeMenuDto>> GetAll()
    {
        var typeMenus = await Db.TypeMenus.ToListAsync();
        return typeMenus.Select(tm => Mapper.Map<TypeMenuDto>(tm)).ToList();
    }
}