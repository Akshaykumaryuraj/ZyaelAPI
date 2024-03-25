using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zyael_Models.Hospitals;
using Zyael_Models.Logins;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public UserLogin _userlogin;
        public IConfiguration config;

        public UserLoginController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userlogin = new UserLogin(httpContextAccessor, config);
            this.config = config;
        }


        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserLoginCredentialAdd(int UserID)
        {
            UserLoginModel item = new UserLoginModel();
            if (UserID > 0)
            {
                item = await _userlogin.UserLoginCredentialAdd(UserID);

                item.UserID = UserID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> UserCredentialDetails_InsertUpdate(UserLoginModel item)
        {
            UserLoginModel test = new UserLoginModel();

            var result = await _userlogin.UserCredentialDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "inserted successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[Controller]")]
        [HttpPost]
        public async Task<IActionResult> SetUserLogin(UserLoginModel item)
        {
            var jwtToken = "";
            UserLoginModel result = new UserLoginModel();
            if (item != null)
            {
                result = await _userlogin.SetUserLogin(item);
                if (result.returnId == 1)
                {

                    var issuer = config["Jwt:Issuer"];
                    var audience = config["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );

                    //                var subject = new ClaimsIdentity(new[]
                    // {
                    //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    //new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    //});

                    var expires = DateTime.UtcNow.AddMinutes(10);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        //Subject = subject,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    jwtToken = tokenHandler.WriteToken(token);
                }
            }
            return Ok(jwtToken);
            //if (result.returnId != -1)
            //{
            //    result.message = "Login success";
            //    return Ok(result);


            //}
            //else
            //{
            //    return BadRequest("not found");

            //}

        }

    }
}