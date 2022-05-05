using Microsoft.EntityFrameworkCore;
using TelegramBot.DataBase.Models;

namespace TelegramBot.DataBase;

public sealed class TelegramBotContext : DbContext
{
    // public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<User> Users => Set<User>();
    public TelegramBotContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=telegram_bot;Username=postgres;Password=admin");
    }
}