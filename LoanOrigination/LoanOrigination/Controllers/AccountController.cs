using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using LoanOrigination.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LoanOrigination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUsersData dal;
        private readonly IConfiguration _config;
        public AccountController(IUsersData dal, IConfiguration _config)
        {
            this.dal = dal;
            this._config = _config;
        }

        [HttpPost]
        [Route("Login/{username}/{pin}")]
        public IActionResult Login(string username, string pin)
        {
            try
            {
                var auth = dal.GetUser(username);
                var secret = _config["secret"];
                using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
                {
                    byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
                    string hashedPin = Convert.ToBase64String(hashBytes); // Convert hash to Base64 string for storage
                    if (hashedPin.Equals(auth.Pin))
                    {

                        var secretKey = _config["jwt:secretKey"];
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                        var tokenParams = new JwtSecurityToken
                        (
                            issuer: _config["jwt:issuer"],
                            audience: _config["jwt:audience"],
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                        );

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.WriteToken(tokenParams);

                        return Ok(new { token = token, firstname = auth.FirstName, lastname = auth.LastName});
                    }
                    else
                    {
                        return BadRequest(new { msg = "Invalid pin" });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { errmsg = ex.Message });
            }
        }
    }
}
