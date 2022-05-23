using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("user")]
[Comment("Пользователи")]
public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public int UserBotId { get; set; }
    public string? Email { get; set; }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Настройка полей
        builder
            .HasKey(b => b.Id);
        builder
            .Property(b => b.Nickname)
            .HasColumnName("nickname")
            .HasComment("Ник пользователя");
        builder
            .Property(b => b.UserBotId)
            .IsRequired()
            .HasColumnName("user_bot_id")
            .HasComment("Пользователи телеграм");
        builder
            .Property(b => b.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .HasDefaultValue(null)
            .HasComment("Почта пользователя");
        #endregion
    }
}