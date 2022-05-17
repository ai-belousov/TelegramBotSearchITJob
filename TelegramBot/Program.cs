// using System;

using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
// using System.Collections.Generic;
// using System.Text;
// using System.Globalization;
// using System.Threading;
// using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.DataBase;
using model = TelegramBot.DataBase.Models;

var botClient = new TelegramBotClient("5179375578:AAHgamcmzMRG1M39RFvGPglgXKxuD44lGd8");
using var cts = new CancellationTokenSource();
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
};
botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token
    );
var message = botClient.GetMeAsync();

Console.ReadLine();

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Type != UpdateType.Message)
        return;
    // Only process text messages
    if (update.Message!.Type != MessageType.Text)
        return;
        
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
            replyMarkup: GetButtons(),
            cancellationToken: cancellationToken);
        GetInlineButtons();
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

IReplyMarkup GetButtons()
{
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new []
    {
        new KeyboardButton[] { },
    })
    {
        ResizeKeyboard = true
    };
    
    return replyKeyboardMarkup;
}
IReplyMarkup GetInlineButtons()
{
    InlineKeyboardMarkup inlineKeyboard = new(new []
    {
        // first row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
            InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
        },
        // second row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
            InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
        },
    });

    return inlineKeyboard;
}
var optionsBuilder = new DbContextOptionsBuilder<TelegramBotContext>();
var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=telegram_bot;Username=postgres;Password=admin").Options;

using (TelegramBotContext db = new TelegramBotContext(options))
{
    // создаем два объекта User
    var tom = new model.User { BotUserId = 6541654, Email = "email@first.ru" };
    var alice = new model.User { BotUserId = 99494, Email = "email@second.ru" };
 
    // добавляем их в бд
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
    
    // Еще один метод, который стоит отметить, это Database.CanConnect()
    // и его асинхронная версия Database.CanConnectAsync().
    // Данный метод возвращает true, если бд доступна, и false, если бд не доступна
    db.Database.CanConnect();
    
    Console.WriteLine("Объекты успешно сохранены");
 
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (model.User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.BotUserId} - {u.Email}");
    }
}