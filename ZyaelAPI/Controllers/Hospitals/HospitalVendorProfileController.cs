using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Hospitals;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Hospitals
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalVendorProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public HospitalVendorProfile _hospitalvendorprofile;


        public HospitalVendorProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _hospitalvendorprofile = new HospitalVendorProfile(httpContextAccessor, config);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllHospitalVendorProfileDetails()
        {
            List<HospitalVendorProfileModel> list = new List<HospitalVendorProfileModel>();
            list = await _hospitalvendorprofile.GetAllHospitalVendorProfileDetails();

            return Ok(list);

        }
    }
}
