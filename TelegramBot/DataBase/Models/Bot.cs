using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("bot")]
[Comment("Телеграм боты")]
public class Bot
{
    public int Id { get; set; }
    public long TelegramBotId { get; set; }
    public string Name { get; set; }
    public List<Menu> Menus { get; set; }

    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        #region Настройка полей
        builder                    
            .HasKey(b => b.Id);
        builder
            .Property(b => b.Id)
            .HasColumnName("id");
        builder
            .Property(b => b.Name)
            .HasColumnName("name")
            .IsRequired(false)
            .HasComment("Название бота");
        builder
            .Property(b => b.TelegramBotId)
            .HasColumnName("telegram_bot_id")
            .HasComment("id телеграм бота");
        #endregion
        
        List<Bot> botsList = new List<Bot>();
        
        botsList.Add(new Bot{Id = 1,TelegramBotId = 5179375578, Name = "Поиск IT-вакансий"});

        builder.HasData(botsList);
    }
}