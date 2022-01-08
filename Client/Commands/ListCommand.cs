using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class ListCommand : Command
    {
        public override async Task Execute(HttpClient client)
        {
            var response = await client.GetAsync("/api/v1/tracks/all");

            await HandleTrackInfoResult(response);
        }
    }
}
