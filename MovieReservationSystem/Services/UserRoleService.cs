using MovieReservationSystem.Models;
using System.Security.Claims;

namespace MovieReservationSystem.Services
{
	public class UserRoleService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserRoleService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor=httpContextAccessor;
		}

		public bool IsAdmin()
		{
			var userRole = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;
			return userRole == "admin"; // Check if user is admin
		}
		public bool IsUser()
		{
			var userRole = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;
			return userRole == "user";
		}	
		public int GetUserId()
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == "userId")?.Value;
			return int.Parse(userId);
		}
	}
}
