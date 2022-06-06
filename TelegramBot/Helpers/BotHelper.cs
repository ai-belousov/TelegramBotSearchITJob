using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Helpers.Interfaces;
using TelegramBot.Repositories.Interfaces;

namespace TelegramBot.Helpers;

public class BotHelper : IBotHelper
{
    private readonly IBotRepository _botRepository;
    private readonly TelegramBotClient _telegramBotClient;
    private readonly CancellationTokenSource _cancellationTokenSource;
    public BotHelper(IBotRepository botRepository, TelegramBotClient telegramBotClient, CancellationTokenSource cancellationTokenSource)
    {
        _botRepository = botRepository;
        _telegramBotClient = telegramBotClient;
        _cancellationTokenSource = cancellationTokenSource;
        //  var _cts = new CancellationTokenSource();

    }

    // public void RunBots()
    // {
    //     var listBot = _botRepository.GetAllBots();
    //     // получить всех ботов из базы
    //     // Console.WriteLine(listBot.ToString());
    //     using var _cancellationTokenSource = new CancellationTokenSource();
    //
    // }

    public void StartBot()
    {

        _telegramBotClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            new ReceiverOptions()
            {
                AllowedUpdates = { } // receive all update types // получать все типы обновлений
            },
            cancellationToken: _cancellationTokenSource.Token
        );
        Console.ReadLine();
    }

    public void StopBot()
    {
        _cancellationTokenSource.Cancel();
    }
    
    async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (update.Type != UpdateType.Message)
            return;
        // Only process text messages
        if (update.Message!.Type != MessageType.Text)
            return;
        
        Console.WriteLine("BotId " + botClient.BotId.ToString());
        // Console.WriteLine("BotId " + botClient.use.ToString());
        
        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text;
        var up = update.Message;
        var lastName = update.Message.Chat.LastName;
            
        
        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            
        // Echo received message text
        try{
            // Message sentMessage = await botClient.SendTextMessageAsync(
            //     chatId: chatId,
            //     text: "Choose a response",
            //
            //     cancellationToken: cancellationToken);
            
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: lastName + " said:\n" + messageText,
                // replyMarkup: GetButtons(),
                cancellationToken: cancellationToken);
            // GetInlineButtons();
        }
        catch (ApiRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
            
    Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
            
        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}