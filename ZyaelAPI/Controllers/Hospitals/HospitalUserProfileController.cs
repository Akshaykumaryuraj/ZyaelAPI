using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Hospitals;
using Zyael_Services;

namespace ZyaelAPI.Controllers.Hospitals
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalUserProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public HospitalUserProfile _hospitaluserprofile;


        public HospitalUserProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _hospitaluserprofile = new HospitalUserProfile(httpContextAccessor, config);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllHospitalUserProfileDetails()
        {
            List<HospitalUserProfileModel> list = new List<HospitalUserProfileModel>();
            list = await _hospitaluserprofile.GetAllHospitalUserProfileDetails();

            return Ok(list);

        }
    }
}
