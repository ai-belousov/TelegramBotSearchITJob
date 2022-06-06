using Telegram.Bot;
using TelegramBot.Helpers;
using TelegramBot.Helpers.Interfaces;
using TelegramBot.Services.Interfaces;
//клас для работы с ботом
//подключены репозитории
namespace TelegramBot.Services;

public class BotService : IBotService
{
    private readonly IBotHelper _botHelper;
    private readonly TelegramBotClient _telegramBotClient;
    
    //

    public BotService(IBotHelper botHelper)
    {
        _botHelper = botHelper;
        Console.WriteLine("The message for check__________");
    }

    public void GetMenu()
    {
        Console.WriteLine("Get menu");
    }
}