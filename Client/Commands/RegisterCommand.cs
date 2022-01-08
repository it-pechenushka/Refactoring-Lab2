using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dto;
using static Client.Helpers.InformationMessageStore;


namespace Client.Commands
{
	public class RegisterCommand : Command
	{
		public override async Task Execute(HttpClient client)
		{
			var user = new RegisterDto();
			PrintInfo(InputUserNameMessage);
			user.Name = InputCommandData();
			PrintInfo(InputUserPasswordMessage);
			user.Password = InputCommandData();

			var response = await client.PostAsJsonAsync("/api/v1/users/new", user);

			if (response.IsSuccessStatusCode)
			{
				PrintInfo(string.Format(AddUserSuccessCommandMessage, $"\"{user.Name}\""));
			}
			else
				PrintInfo(await response.Content.ReadAsStringAsync());
		}
	}
}
