using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Helpers;
using static Client.Helpers.InformationMessageStore;

namespace Client.Commands
{
    public class AddCommand : Command
    {
        public override async Task Execute(HttpClient client)
        {
            var track = new TrackInfo();
            PrintInfo(InputAuthorMessage);
            track.Author = InputCommandData();
            PrintInfo(InputCompositionMessage);
            track.Composition = InputCommandData();

            var response = await client.PostAsJsonAsync("/api/v1/tracks", track);

            if (response.IsSuccessStatusCode)
                PrintInfo(string.Format(AddSuccessCommandMessage, $"\"{track.Author} - {track.Composition}\""));
            else
                PrintInfo(await response.Content.ReadAsStringAsync());
        }
    }
}