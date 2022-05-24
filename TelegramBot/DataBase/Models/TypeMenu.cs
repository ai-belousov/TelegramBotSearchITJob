using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.DataBase.Models;

[Table("type_menu")]
[Comment("Типы меню")]
public class TypeMenu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Menu> Menus { get; set; }
    
    public void Configure(EntityTypeBuilder<TypeMenu> builder)
    {
        builder                    
            .HasKey(tm => tm.Id);
        builder
            .Property(tm => tm.Id)
            .HasColumnName("id");
        builder
            .Property(tm => tm.Name)
            .HasColumnName("name")
            .IsRequired(false)
            .HasComment("Тип меню");
        builder.ToTable("type_menu");
    }
}