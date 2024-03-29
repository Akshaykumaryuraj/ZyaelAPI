using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Logins;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public UserProfie _userprofile;
        public IConfiguration config;

        public UserProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userprofile = new UserProfie(httpContextAccessor, config);
            this.config = config;
        }


        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserProfileDetailsAdd(int UserPID)
        {
            UserProfileModel item = new UserProfileModel();
            if (UserPID > 0)
            {
                item = await _userprofile.UserProfileDetailsAdd(UserPID);

                item.UserPID = UserPID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> UserProfileDetails_InsertUpdate(UserProfileModel item)
        {
            UserProfileModel test = new UserProfileModel();

            var result = await _userprofile.UserProfileDetails_InsertUpdate(item);

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


    }
}
