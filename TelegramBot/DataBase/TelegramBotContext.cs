using Microsoft.EntityFrameworkCore;
using TelegramBot.DataBase.Models;

namespace TelegramBot.DataBase;

public sealed class TelegramBotContext : DbContext
{
    public DbSet<User> Users => Set<User>();    // подключаем таблицу из папки models
    public TelegramBotContext(DbContextOptions<TelegramBotContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(_connectionString);
    // }
}