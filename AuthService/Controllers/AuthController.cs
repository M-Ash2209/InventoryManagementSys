using CrudApp.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.Business.Features.Auth.Command.AddUsers;
using CrudApp.Features.Auth.Query.GetUserById;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly ISender _sender;
        public AuthController(IConfiguration config, ISender sender)
        {
            _config = config;
            _sender = sender;
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(AddUsersCommand addUsersCommand)
        {
            byte[] password = Encoding.UTF8.GetBytes(addUsersCommand.Password);
            addUsersCommand.Password = Convert.ToBase64String(password);
            var UserId = await _sender.Send(addUsersCommand);
            if (UserId == null) return BadRequest();
            return Ok(UserId);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = await _sender.Send(new GetUserByIdQuery(Id));
            if(user == null) return NotFound();
            return Ok(user);
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin model)
        {
            if (model.Username == "admin" && model.Password == "password") 
            //if (true)
            {
                var token = GenerateToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }


        [HttpPost("verify")]
        public IActionResult Login([FromBody] string token)
        {
            // var jwtSettings = _config["JwtSettings:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key
                }, out SecurityToken validatedToken);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

            //return Unauthorized();
        }


        private string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub, username),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                /* issuer: _config["JwtSettings:Issuer"],
                 audience: _config["JwtSettings:Audience"],*/
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiryInMinutes"])),
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //public class UserLogin
        //{
        //    public string Username { get; set; }
        //    public string Password { get; set; }
        //}
    }
}




