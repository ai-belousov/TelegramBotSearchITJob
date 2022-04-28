// using System;
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


Console.WriteLine($"Start listening for @{message.Id}");
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
        ResizeKeyboard = true,
        
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

Console.WriteLine("Hello, World!");