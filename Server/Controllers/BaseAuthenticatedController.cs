using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	[AllowAnonymous]
	public abstract class BaseAuthenticatedController : Controller
	{

		protected bool CheckCredentials()
		{
			if (User.Identity is {IsAuthenticated: false})
			{
				return false;
			}

			return true;
		}
	}
}
