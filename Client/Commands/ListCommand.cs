using System.Net.Http;
using System.Threading.Tasks;
using static Client.Helpers.InformationMessageStore;

namespace Client.Commands
{
    public class ListCommand : Command
    {
        public override async Task Execute(HttpClient client)
        {
            PrintInfo(ListCommandMessage);
            
            var response = await client.GetAsync("/api/v1/tracks/all");

            await HandleTrackInfoResult(response);
        }
    }
}