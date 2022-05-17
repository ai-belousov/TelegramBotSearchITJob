using Microsoft.EntityFrameworkCore;
using TelegramBot.DataBase.Models;

namespace TelegramBot.DataBase;

public sealed class TelegramBotContext : DbContext
{
    // public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<User> Users => Set<User>();    // подключаем таблицу из папки models
    // private readonly string _connectionString;
    // public TelegramBotContext(string connectionString)
    // {
    //     _connectionString = connectionString;   // получаем извне строку подключения
    //     Database.EnsureCreated();   // создает бд и таблицы из папки models если их нет
    // }
    public TelegramBotContext(DbContextOptions<TelegramBotContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(_connectionString);
    // }
}