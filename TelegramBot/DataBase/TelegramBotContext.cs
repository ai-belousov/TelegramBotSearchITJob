using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.DataBase.Models;

namespace TelegramBot.DataBase;

public sealed class TelegramBotContext : DbContext
{
    // подключаем таблицы из папки models
    public DbSet<User> Users => Set<User>();
    public DbSet<TypeMenu> TypeMenus => Set<TypeMenu>();
    public DbSet<Bot> Bots => Set<Bot>();
    public DbSet<Menu> Menus => Set<Menu>();
    
    public DbSet<UserSettings> UsersSettings => Set<UserSettings>();

    public TelegramBotContext(DbContextOptions<TelegramBotContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message)); // логирование в Debag Output
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TypeMenu>(new TypeMenu().Configure);
        builder.Entity<Bot>(new Bot().Configure);
        builder.Entity<Menu>(new Menu().Configure);
        builder.Entity<User>(new User().Configure);
        builder.Entity<UserSettings>(new UserSettings().Configure);
    }
}