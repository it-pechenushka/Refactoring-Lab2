using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dto;
using static Client.Helpers.InformationMessageStore;

namespace Client.Commands
{
    public abstract class Command
    {
        public abstract Task Execute(HttpClient client);

        protected string InputCommandData() =>
            Console.ReadLine()?.Trim();
        
        protected static void PrintInfo(string message) =>
            Console.WriteLine(message);

        protected async Task HandleTrackInfoResult(HttpResponseMessage response)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                PrintInfo(ListCommandMessage);
                var result = JsonSerializer.Deserialize<IList<TrackDto>>(responseData);
                if (result != null)
                {
                    foreach (var track in result) 
                        PrintInfo(track.ToString());
                }
                else
                    PrintInfo(NotFoundResultMessage);
            }
            else
            {
                PrintInfo(response.StatusCode.ToString());
                PrintInfo(responseData);
            }
        }
    }
}
