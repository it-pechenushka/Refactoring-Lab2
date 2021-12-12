using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using Server.Database;
using Server.Model;

namespace Server.Services
{
	public interface IUserService
	{
		List<UserDto> GetUsers();
		Task CreateUser(RegisterDto user);
		UserDto GetUserByName(string userName);
		bool CompareUserPassword(string userName, string password);
	}


	public class UserService : IUserService
	{
		private readonly ApplicationDbContext _dbContext;

		public UserService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<UserDto> GetUsers()
		{
			return _dbContext.Users.Select(u => u.ToDto()).ToList();
		}

		public async Task CreateUser(RegisterDto user)
		{
			await _dbContext.Users.AddAsync(new UserRecord()
			{
				Name = user.Name,
				Password = user.Password,
			});
			await _dbContext.SaveChangesAsync();
		}

		public UserDto GetUserByName(string userName)
		{
			return _dbContext.Users.First(u => u.Name.Equals(userName)).ToDto();
		}

		public bool CompareUserPassword(string userName, string password)
		{
			var dbPassword = _dbContext.Users.First(u => u.Name.Equals(userName)).Password;
			return dbPassword.Equals(password);
		}
	}
}
