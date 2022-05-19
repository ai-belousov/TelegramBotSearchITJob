using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.DataBase.Models;

namespace TelegramBot.DataBase;

public sealed class TelegramBotContext : DbContext
{
    public DbSet<User> Users => Set<User>();    // подключаем таблицу из папки models

    public TelegramBotContext(DbContextOptions<TelegramBotContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message)); // логирование в Debag Output
    }
}