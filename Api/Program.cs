// See https://aka.ms/new-console-template for more information
// using Httpcli
// Console.WriteLine("Hello, World!");

using Api.DTO.Request;using Api.HttpClients;
using Api.HttpClients.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// private readonly HttpClient client = new HttpClient();

// static readonly HttpClient client = new HttpClient();

// В теле запроса необходимо передать дополнительные параметры:
// new HttpClient();
//grant_type=client_credentials
//client_id и client_secret - необходимо заполнить значениями, выданными при регистрации приложения

IHost hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            // .AddSingleton<HttpClient>()
            .AddHttpClient<IHhHttpClient,HhHttpClient>();
    }).Build();

// hostBuilder.Services.GetRequiredService<HttpClient>();

var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();


var authDto = new AuthDTO();

authDto.ClientId = config.GetSection("HhApi").GetRequiredSection("ClientID").Value;
authDto.ClientSecret = config.GetSection("HhApi").GetRequiredSection("ClientSecret").Value;

hostBuilder.Services.GetRequiredService<IHhHttpClient>().AuthClient(authDto);
// hostBuilder.Services.

    //
//
//
//     // Call asynchronous network methods in a try/catch block to handle exceptions.
//     try	
//     {
//         HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
//         response.EnsureSuccessStatusCode();
//         string responseBody = await response.Content.ReadAsStringAsync();
//         // Above three lines can be replaced with new helper method below
//         // string responseBody = await client.GetStringAsync(uri);
//
//         Console.WriteLine(responseBody);
//     }
//     catch(HttpRequestException e)
//     {
//         Console.WriteLine("\nException Caught!");	
//         Console.WriteLine("Message :{0} ",e.Message);
//     }

// var builder = new HostBuilder()
//     .ConfigureServices((hostContext, services) =>
//     {
//         services.AddHttpClient();
//         // services.AddTransient<MyApplication>();
//     }).UseConsoleLifetime();
 // builder.
// var host = builder.Build();
//  
// using (var serviceScope = host.Services.CreateScope())
// {
//     var services = serviceScope.ServiceProvider;
//  
//     try
//     {
//         var myService = services.GetRequiredService<MyApplication>();
//         var result = await myService.Run();
//  
//         Console.WriteLine(result);
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine("Error Occured");
//     }
// }
//  
// return 0;