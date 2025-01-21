using Microsoft.AspNetCore.Mvc;
using MovieReservationSystem.Models;
using MovieReservationSystem.Services;

namespace MovieReservationSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserRoleService _roleService;
		private readonly AuthService _authService;

		public UserController(UserRoleService roleService, AuthService authService)
		{
			_roleService=roleService;
			_authService=authService;
		}

		[HttpGet("register")]
		public ActionResult<IEnumerable<UserModel>> Register(UserRegisterDTO userDto)
		{
			var result = _authService.RegisterUser(userDto);
			if (!result)
			{
				return BadRequest("User already exists");
			}
			return Ok("User registered successfully");
		}
		[HttpPost("login")]
		public ActionResult<string> Login(UserLoginDTO loginDto)
		{
			var token = _authService.Login(loginDto);
			if (token == null)
			{
				return BadRequest("Invalid username or password");
			}
			return Ok(token);
		}
	}
}
