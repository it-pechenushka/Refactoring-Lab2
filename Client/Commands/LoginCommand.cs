using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dto;
using static Client.Helpers.InformationMessageStore;


namespace Client.Commands
{
	public class LoginCommand : Command
	{
		public override async Task Execute(HttpClient client)
		{
			var user = new RegisterDto();
			PrintInfo(InputUserNameMessage);
			user.Name = InputCommandData();
			PrintInfo(InputUserPasswordMessage);
			user.Password = InputCommandData();

			var response = await client.PostAsJsonAsync("/api/v1/users/login", user);

			if (response.IsSuccessStatusCode)
			{
				PrintInfo(string.Format(LoginSuccessCommandMessage));
			}
			else
				PrintInfo(await response.Content.ReadAsStringAsync());
		}
	}
}
