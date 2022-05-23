using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("bot")]
public class Bot
{
    public int Id { get; set; }
    public int BotId { get; set; }
    public string Name { get; set; }
    
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        #region Настройка полей
        builder
            .HasKey(b => b.Id);
        builder
            .Property(b => b.Name)
            .HasColumnName("name")
            .IsRequired(false)
            .HasComment("Название бота");
        builder
            .Property(b => b.BotId)
            .HasColumnName("user_bot_id")
            .HasComment("Пользователи телеграм");
        #endregion
    }
}