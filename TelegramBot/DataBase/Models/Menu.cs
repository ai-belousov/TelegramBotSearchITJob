using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("menu")]
[Comment("Меню(кнопки выбора) бота")]
public class Menu
{
    private const int
        SPECIALITY = 1,
        TYPE_MENU_FORMAT_OF_WORK = 2,
        TYPE_MENU_SALARY = 3,
        BOT_ID_IT = 1;
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
        
        AddDefaultDataForBotIt(builder);
    }

    private void AddDefaultDataForBotIt(EntityTypeBuilder<Menu> builder)
    {
        builder.HasData(
            new Menu {Id = 1, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Java/Scala"},
            new Menu {Id = 2, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Python" },
            new Menu {Id = 3, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "C#" },
            new Menu {Id = 4, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "C/C++" },
            new Menu {Id = 5, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Go" },
            new Menu {Id = 6, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Ruby" },
            new Menu {Id = 7, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "PHP" },
            new Menu {Id = 8, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Frontend" },
            new Menu {Id = 9, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Node.js" },
            new Menu {Id = 10, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "DevOps" },
            new Menu {Id = 11, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "QA Manual" },
            new Menu {Id = 12, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "QA Auto" },
            new Menu {Id = 13, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Data Scientist" },
            new Menu {Id = 14, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Product Manager" },
            new Menu {Id = 15, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Product Analyst" },
            new Menu {Id = 16, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Project Manager" },
            new Menu {Id = 17, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "CTO / Architect" },
            new Menu {Id = 18, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Design & UX" },
            new Menu {Id = 19, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "System Analyst" },
            new Menu {Id = 20, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "IT HR / Recruiter" },
            
            new Menu {Id = 21, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Москва (гибрад или офис)" },
            new Menu {Id = 22, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Санкт-Петербург (гибрад или офис)" },
            new Menu {Id = 23, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Полная удаленка" },
            new Menu {Id = 24, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Релокейт за рубеж" },
            
            new Menu {Id = 25, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 150К ₽/мес" },
            new Menu {Id = 26, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 200К ₽/мес" },
            new Menu {Id = 27, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 250К ₽/мес" },
            new Menu {Id = 28, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 350К ₽/мес" }
            );
    }
}

