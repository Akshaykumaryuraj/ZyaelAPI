using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Doctors;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Doctors
{
    [Route("api/[controller]")]
    public class DoctorProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public DoctorProfile _doctorprofile;


        public DoctorProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _doctorprofile = new DoctorProfile(httpContextAccessor, config);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsProfileDetails()
        {
            List<DoctorRegistrationModel> list = new List<DoctorRegistrationModel>();
            list = await _doctorprofile.GetAllDoctorsProfileDetails();

            return Ok(list);

        }

        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorsProfileDetails(int DoctorPId)
        {
            DoctorProfileModel item = new DoctorProfileModel();
            if (DoctorPId > 0)
            {
                item = await _doctorprofile.GetDoctorsProfileDetails(DoctorPId);

                item.DoctorPId = DoctorPId;
            }

            return Ok(item);

        }
    }
}
