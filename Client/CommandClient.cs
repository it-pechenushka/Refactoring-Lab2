using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Client.Helpers.InformationMessageStore;

namespace Client
{
    public class CommandClient
    {
        private readonly HttpClient _client;

        public CommandClient()
        {
            _client = new HttpClient();
        }
        
        public async Task StartClientAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            
            Console.WriteLine(UsageCommandsMessage + "\n" + InputCommandMessage);
            string input;
            while ((input = Console.ReadLine()?.Trim()) != null)
            {
                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase) || input == "q") break;
                
                try
                {
                    var command = CommandHandler.HandleCommandType(input);
                    await command.Execute(_client);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                Console.WriteLine(InputCommandMessage);
            }
            
            _client.Dispose();
        }
    }
}