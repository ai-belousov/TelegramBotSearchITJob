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
    public int BotId { get; set; }
    
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        #region Настройка полей
        builder
            .HasKey(b => b.Id);
        builder
            .Property(b => b.TypeMenuId)
            .IsRequired()
            .HasColumnName("type_menu_id")
            .HasComment("id типа меню");
        builder
            .Property(b => b.Value)
            .IsRequired()
            .HasColumnName("value")
            .HasComment("Значение кнопки меню");
        builder
            .Property(b => b.BotId)
            .IsRequired()
            .HasColumnName("bot_id")
            .HasComment("id бота");
        #endregion
    }
}