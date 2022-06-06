using System.Collections;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Api.DTO.Request;
using Api.HttpClients.Interfaces;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Api.HttpClients;

public class HhHttpClient: IHhHttpClient
{
    private readonly HttpClient _httpClient;

    public HhHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public  async  Task AuthClient(AuthDTO authDto)
    {
        string url = "https://hh.ru/oauth/token";
        var client = new RestClient(url);
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("grant_type","client_credentials");
        request.AddParameter("client_id","TTVRSPODGA9C0C8PJ6J4RCB401K89KA0NPKVAD9PAUOCJKQAGG0DU1VUOKFNPLOQ");
        request.AddParameter("client_secret","Q36D679A9ONII9G964NNMF4NAC8MOCH3R1DRTJ1E9GVG5MFLOF83F5BEUCT5QUPL");

        var response = client.PostAsync(request);
        var content = response.Result.Content.ToString();
        // var responseResult = response.Result;

        Console.WriteLine(content);
        // Console.WriteLine("response.ToString()");
        
        
        
        // IRestResponse response = client.Execute(request);
        // UserResponse resp = JsonConvert.DeserializeObject<UserResponse>(response.Content);
        // _httpClient.DefaultRequestHeaders.Remove("Content-Type");

        // var httpRequest = new HttpRequestMessage();
        // {
        //     RequestUri = new Uri($"https://hh.ru/oauth/token", UriKind.RelativeOrAbsolute),
        //     // Content = JsonContent.Create(authDto),
        //     Method = HttpMethod.Post,
        // };

        // httpRequest.Headers.Add("grant_type","client_credentials");
        // httpRequest.Headers.Add("client_id", "TTVRSPODGA9C0C8PJ6J4RCB401K89KA0NPKVAD9PAUOCJKQAGG0DU1VUOKFNPLOQ");
        // httpRequest.Headers.Add("client_secret", "Q36D679A9ONII9G964NNMF4NAC8MOCH3R1DRTJ1E9GVG5MFLOF83F5BEUCT5QUPL");
        // httpRequest.Method = HttpMethod.Post;
        // httpRequest.RequestUri = new Uri("https://hh.ru/oauth/token");
        //
        //
        // // HttpResponseMessage? response = null;
        //
        // try
        // {
        //     // _httpClient.DefaultRequestHeaders.Remove("Content-Type");
        //     // _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        //     Console.WriteLine("I'm leave");
        //     // response = await _httpClient.SendAsync(httpRequest);
        //     // response.EnsureSuccessStatusCode();
        //
        //     Console.WriteLine("I'm not leave");
        //     // Console.WriteLine(response.ToString());
        // }
        // catch (Exception e)
        // {
        // Console.WriteLine(e);
        // throw;
        // }
        //
        // Console.WriteLine($"response.ToString()\n");
        // return "asdfg";
    }
    
    // private async Task LogRequest(HttpRequestMessage request, LogEventLevel level)
    // {
    //     var content = string.Empty;
    //     if (request.Content is not null)
    //     {
    //         content = await request.Content.ReadAsStringAsync(_applicationHolder.Token);
    //     }
    //     _logger.LogWithLevel(level, "Send request to magnum {httpMethod} {httpUrl} {content}", request.Method, request.RequestUri?.ToString() ?? string.Empty, content);
    // }
    // private async Task LogResponse(HttpResponseMessage? response, LogEventLevel level)
    // {
    //     if (response is null)
    //     {
    //         _logger.LogWithLevel(level, "Response is empty");
    //         return;
    //     }
    //     
    //     _logger.LogWithLevel(level, "Receive skillaz magnum {httpStatus} {content}", response.StatusCode, await response.Content.ReadAsStringAsync(_applicationHolder.Token));
    // }
}