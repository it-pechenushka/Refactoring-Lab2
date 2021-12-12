using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dto;
using static Client.Helpers.InformationMessageStore;


namespace Client.Commands
{
	public class LogoutCommand : Command
	{
		public override async Task Execute(HttpClient client)
		{
			var response = await client.PostAsync("/api/v1/users/logout", null);

			if (response.IsSuccessStatusCode)
			{
				PrintInfo(string.Format(LogoutSuccessCommandMessage, $"\"{response.Headers}\""));
			}
			else
				PrintInfo(await response.Content.ReadAsStringAsync());
		}
	}
}
