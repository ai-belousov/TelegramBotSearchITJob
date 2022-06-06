using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TelegramBot.Data;
using TelegramBot.Repositories.Base;
using TelegramBot.Repositories.DTO;
using TelegramBot.Repositories.Interfaces;

namespace TelegramBot.Repositories;

public class UserRepository : BaseRepository
{
    public UserRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
    
    // public async Task<UserDto> GetByChatId(ulong id)
    //     => Mapper.Map<UserDto>(await Db.Users.FirstOrDefaultAsync(_ => _.ChatId == id));
}