using Microsoft.IdentityModel.Tokens;
using MovieReservationSystem.DataAccess;
using MovieReservationSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieReservationSystem.Services
{
	public class AuthService
	{
		private readonly MovieReservationDbContext _dbContext;
		private readonly IConfiguration _config;

		public AuthService(MovieReservationDbContext dbContext , IConfiguration config)
		{
			_config = config;
			_dbContext=dbContext;
		}
		public bool RegisterUser(UserRegisterDTO userDto)
		{
			if (_dbContext.Users.Any(u => u.Username == userDto.Username || u.Email == userDto.Email))
			{
				return false; // User already exists
			}
			var user = new UserModel()
			{
				Username = userDto.Username,
				Name = userDto.Name,
				Email = userDto.Email,
				Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
				Role = "user" // Default role
			};

			_dbContext.Users.Add(user);
			_dbContext.SaveChanges();
			return true;
		}

		public string Login(UserLoginDTO loginDto)
		{
			var user = _dbContext.Users.SingleOrDefault(u => u.Username == loginDto.Username);
			if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
			{
				return null; // Invalid username or password
			}
			return GenerateJwtToken(user);
		}

		private string GenerateJwtToken(UserModel user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim("userId", user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role)
			};

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
