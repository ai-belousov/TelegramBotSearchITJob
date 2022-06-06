using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBot.Data;
using model = TelegramBot.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.Helpers;
using TelegramBot.Helpers.Interfaces;
using TelegramBot.Repositories;
using TelegramBot.Repositories.Interfaces;

var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

//  *Service Тип сервиса*	    *В рамках одного http-запроса*      *Для двух разных http-запросов*  
//
//  *Transient*	                Новый инстанс	                    Новый инстанс
//  *Scoped*                    Уже существующий инстанс            Новый инстанс
//  *Singleton*                 Уже существующий инстанс            Уже существующий инстанс
IHost hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddDbContext<Context>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")!))
            .AddAutoMapper(typeof(Mapping))
            //repository
            .AddScoped<IBotRepository, BotRepository>()
            // .AddScoped<IUserRepository, UserRepository>()
            // .AddScoped<IBotRepository, BotRepository>()
            // .AddScoped<IBotRepository, BotRepository>()
            // .AddSingleton<IBotManagerHelper, BotManagerHelper>()
            // .AddSingleton<IBotService, BotService>()
            // .AddSingleton<TelegramBotClient>()
            .AddSingleton<CancellationTokenSource>()
            .AddSingleton(
                new TelegramBotClient(
                    config
                        .GetSection("TelegramBot")
                        .GetRequiredSection("Token")
                        .Value!
                    )
                )
            .AddSingleton<IBotHelper, BotHelper>()
            // .AddTransient<>()
            ;
    }).Build();

hostBuilder.Services.GetRequiredService<IBotHelper>().StartBot();


// var botClient = hostBuilder.Services.GetRequiredService<TelegramBotClient>();
// botClient.StartReceiving(
//     HandleUpdateAsync,
//     HandleErrorAsync,
//     new ReceiverOptions
//     {
//         AllowedUpdates = { } // receive all update types
//     },
//     cancellationToken: cts.Token
// );
// botClient.GetMeAsync();
// hostBuilder.Services.GetRequiredService<IBotManagerHelper>().RunBots();
// services
// Console.ReadLine();
// cts.Cancel();

// var tom = new model.User { Email = "email@first.ru" };
// var alice = new model.User { Email = "email@second.ru" };
//
// var b = hostBuilder.Services.GetRequiredService<TelegramBotContext>();
// var users = b.Users;
//
// users.Add(tom);
// users.Add(alice);
//
// b.SaveChanges();
//
// foreach (model.User user in users)
// {
//     Console.WriteLine($"{user.Id}. - {user.Email}");
// }

// string token = config.GetSection("TelegramBot").GetRequiredSection("Token").Value; // получаем ключ для телеграм бота

// var client = services.GetRequiredService<DiscordShardedClient>();

// // инициализация Бота
// var botClient = new TelegramBotClient(token);
//
// using var cts = new CancellationTokenSource();
// var receiverOptions = new ReceiverOptions
// {
//     AllowedUpdates = { } // receive all update types
// };
// botClient.StartReceiving(
//     HandleUpdateAsync,
//     HandleErrorAsync,
//     receiverOptions,
//     cancellationToken: cts.Token
//     );
// var message = botClient.GetMeAsync();
//
// // Console.ReadLine();
//
// cts.Cancel(); // выключает бота по завершению






// IReplyMarkup GetButtons()
// {
//     ReplyKeyboardMarkup replyKeyboardMarkup = new(new []
//     {
//         new KeyboardButton[] { },
//     })
//     {
//         ResizeKeyboard = true
//     };
//     
//     return replyKeyboardMarkup;
// }
// IReplyMarkup GetInlineButtons()
// {
//     InlineKeyboardMarkup inlineKeyboard = new(new []
//     {
//         // first row
//         new []
//         {
//             InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
//             InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
//         },
//         // second row
//         new []
//         {
//             InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
//             InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
//         },
//     });
//
//     return inlineKeyboard;
// }

