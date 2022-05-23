using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("user_settings")]
[Comment("Настройки пользователей")]
public partial class UserSettings
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MenuId { get; set; }

    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder
            .HasKey(us => us.Id);
        builder
            .Property(us => us.UserId)
            .IsRequired()
            .HasColumnName("user_settings")
            .HasComment("id пользователя");
        builder
            .Property(us => us.MenuId);
    }
}