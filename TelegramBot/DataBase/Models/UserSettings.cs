using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("user_settings")]
[Comment("Настройки пользователей")]
public partial class UserSettings
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    public int CreatedAt { get; set; }

    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder
            .HasKey(us => new { us.MenuId, us.UserId });
        builder
            .Property(us => us.UserId)
            .HasColumnName("user_id");
        builder
            .Property(us => us.MenuId)
            .HasColumnName("menu_id");
        builder
            .Property(us => us.CreatedAt)
            .HasColumnName("created_at")
            .HasComment("Дата создания")
            .HasDefaultValue(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());

        builder
            .HasOne(us => us.User)
            .WithMany(u => u.UserSettingsList)
            .HasForeignKey(us => us.UserId);
        builder
            .HasOne(us => us.Menu)
            .WithMany(m => m.UserSettingsList)
            .HasForeignKey(us => us.MenuId);
        
    }
}