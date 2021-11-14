using System.Threading.Tasks;

namespace Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new CommandClient();
            await client.StartClientAsync();
        }
    }
}