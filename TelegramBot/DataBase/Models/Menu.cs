using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("menu")]
[Comment("Меню(кнопки выбора) бота")]
public class Menu
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int TypeMenuId { get; set; }
    public TypeMenu TypeMenu { get; set; }
    public int BotId { get; set; }
    public Bot Bot { get; set; }
    public List<UserSettings> UserSettingsList { get; set; }
   
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        #region Настройка полей
        builder
            .HasKey(m => m.Id);
        builder
            .Property(m => m.Id)
            .HasColumnName("id");
        builder
            .Property(m => m.TypeMenuId)
            .IsRequired()
            .HasColumnName("type_menu_id")
            .HasComment("id типа меню");
        builder
            .Property(m => m.Value)
            .IsRequired()
            .HasColumnName("value")
            .HasComment("Значение кнопки меню");
        builder
            .Property(m => m.BotId)
            .IsRequired()
            .HasColumnName("bot_id")
            .HasComment("id бота");
        #endregion
        
        #region Настройка связей
        builder
            .HasOne(b => b.TypeMenu)
            .WithMany(tm => tm.Menus)
            .HasForeignKey(m => m.TypeMenuId);
        builder
            .HasOne(m => m.Bot)
            .WithMany(b => b.Menus)
            .HasForeignKey(m => m.BotId);
        #endregion
    }
}

