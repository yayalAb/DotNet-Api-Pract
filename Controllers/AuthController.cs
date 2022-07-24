using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MVC_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static models.User user = new models.User();

        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<models.User>> Register(models.UserDto requst)
        {
            CreatePasswordHash(requst.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.Username = requst.Username;
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            return Ok(user);

        }
         
        [HttpPost("Login")]
        public async Task<ActionResult<String>> Login(models.UserDto requst)
        {
            if (user.Username != requst.Username)
            {
                return BadRequest("user not found");  
            }
            if(!VerifyPasswordHash( user.Username, user.PasswordHash, user.PasswordSalt))
            {
                 return BadRequest("Wrong password!");
            }
            String token = CreateToken(user);
            return Ok(token);
        }

        private String CreateToken(models.User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var Token = new JwtSecurityToken(

                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(Token);


            return jwt;
        }

        private void CreatePasswordHash(String Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }

        private bool VerifyPasswordHash(String Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return ComputedHash.SequenceEqual(PasswordHash);
            }
        }



    }
}
