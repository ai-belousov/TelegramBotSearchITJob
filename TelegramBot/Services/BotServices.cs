using Telegram.Bot;
using TelegramBot.Services.Interfaces;
//клас для работы с ботом
//подключены репозитории
namespace TelegramBot.Services;

public class BotService : IBotService
{
    
    private readonly TelegramBotClient _telegramBotClient;
    
    //

    public BotService()
    {
        Console.WriteLine("The message for check");
    }

    public void GetMenu()
    {
        Console.WriteLine("Get menu");
    }
}