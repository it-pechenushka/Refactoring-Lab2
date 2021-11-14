using System.Net.Http;
using System.Threading.Tasks;
using static Client.Helpers.InformationMessageStore;

namespace Client.Commands
{
    public class SearchCommand : Command
    {
        public override async Task Execute(HttpClient client)
        {
            PrintInfo(SearchCommandMessage);
            var data = InputCommandData();
            
            var response = await client.GetAsync($"/api/v1/tracks?partName={data}");

            await HandleTrackInfoResult(response);
        }
    }
}