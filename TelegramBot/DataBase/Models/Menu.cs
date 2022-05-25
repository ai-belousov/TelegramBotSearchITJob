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
        List<Menu> menusList = new List<Menu>();
        
        menusList.Add(new Menu{Id = 1, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Java/Scala"});
        menusList.Add(new Menu{Id = 2, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Python" });
        menusList.Add(new Menu{Id = 3, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "C#" });
        menusList.Add(new Menu{Id = 4, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "C/C++" });
        menusList.Add(new Menu{Id = 5, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Go" });
        menusList.Add(new Menu{Id = 6, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Ruby" });
        menusList.Add(new Menu{Id = 7, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "PHP" });
        menusList.Add(new Menu{Id = 8, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Frontend" });
        menusList.Add(new Menu{Id = 9, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Node.js" });
        menusList.Add(new Menu{Id = 10, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "DevOps" });
        menusList.Add(new Menu{Id = 11, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "QA Manual" });
        menusList.Add(new Menu{Id = 12, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "QA Auto" });
        menusList.Add(new Menu{Id = 13, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Data Scientist" });
        menusList.Add(new Menu{Id = 14, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Product Manager" });
        menusList.Add(new Menu{Id = 15, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Product Analyst" });
        menusList.Add(new Menu{Id = 16, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Project Manager" });
        menusList.Add(new Menu{Id = 17, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "CTO / Architect" });
        menusList.Add(new Menu{Id = 18, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "Design & UX" });
        menusList.Add(new Menu{Id = 19, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "System Analyst" });
        menusList.Add(new Menu{Id = 20, TypeMenuId = SPECIALITY, BotId = BOT_ID_IT, Value = "IT HR / Recruiter" });

        menusList.Add(new Menu{Id = 21, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Москва (гибрад или офис)" });
        menusList.Add(new Menu{Id = 22, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Санкт-Петербург (гибрад или офис)" });
        menusList.Add(new Menu{Id = 23, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Полная удаленка" });
        menusList.Add(new Menu{Id = 24, TypeMenuId = TYPE_MENU_FORMAT_OF_WORK, BotId = BOT_ID_IT, Value = "Релокейт за рубеж" });

        menusList.Add(new Menu{Id = 25, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 150К ₽/мес" });
        menusList.Add(new Menu{Id = 26, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 200К ₽/мес" });
        menusList.Add(new Menu{Id = 27, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 250К ₽/мес" });
        menusList.Add(new Menu{Id = 28, TypeMenuId = TYPE_MENU_SALARY, BotId = BOT_ID_IT, Value = "от 350К ₽/мес" });

        builder.HasData(menusList);
    }
}

