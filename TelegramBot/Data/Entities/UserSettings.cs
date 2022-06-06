using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.Data.Entities;

[Table("user_settings")]
[Comment("Настройки пользователей")]
public partial class UserSettings
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    public DateTime  CreatedTimestamp  { get; set; }

    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        #region Настройка полей
        builder
            .HasKey(us => new { us.MenuId, us.UserId });
        builder
            .Property(us => us.UserId)
            .HasColumnName("user_id");
        builder
            .Property(us => us.MenuId)
            .HasColumnName("menu_id");
        builder
            .Property(us => us.CreatedTimestamp)
            .HasColumnName("created_at")
            .IsRequired()
            .HasConversion(v => v, v => DateTime.Now)
            .HasComment("Дата создания");

        builder
            .HasOne(us => us.User)
            .WithMany(u => u.UserSettingsList)
            .HasForeignKey(us => us.UserId);
        builder
            .HasOne(us => us.Menu)
            .WithMany(m => m.UserSettingsList)
            .HasForeignKey(us => us.MenuId);
        #endregion
    }
}