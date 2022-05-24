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
    public List<UserSettings> UserSettingsList { get; set; }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Настройка полей
        builder                    
            .HasKey(u => u.Id);
        builder
            .Property(u => u.Id)
            .HasColumnName("id");
        builder
            .Property(u => u.Nickname)
            .HasColumnName("nickname")
            .HasComment("Ник пользователя");
        builder
            .Property(u => u.UserBotId)
            .IsRequired()
            .HasColumnName("user_bot_id")
            .HasComment("Пользователи телеграм");
        builder
            .Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .HasDefaultValue(null)
            .HasComment("Почта пользователя");

        #endregion

        #region Настройка связей

        #endregion
    }
}