using System.Net.Http;
using System.Threading.Tasks;
using static Client.Helpers.InformationMessageStore;

namespace Client.Commands
{
    public class DeleteCommand : Command
    {
        public override async Task Execute(HttpClient client)
        {
            PrintInfo(DeleteCommandMessage);
            var track = InputCommandData();
            
            var response = await client.DeleteAsync($"/api/v1/tracks?fullName={track}");

            if (response.IsSuccessStatusCode)
                PrintInfo(string.Format(DeleteSuccessMessage, $"\"{track}\""));
            else
                PrintInfo(await response.Content.ReadAsStringAsync());
        }
    }
}