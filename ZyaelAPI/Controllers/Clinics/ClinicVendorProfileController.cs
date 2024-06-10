using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Clinics;
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;
using Zyael_Services;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.InternalDoctor;

namespace ZyaelAPI.Controllers.Clinics
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicVendorProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public ClinicVendorProfile _clinicvendorprofile;


        public ClinicVendorProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _clinicvendorprofile = new ClinicVendorProfile(httpContextAccessor, config);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllClinicVendorProfileDetails()
        {
            List<ClinicVendorProfileModel> list = new List<ClinicVendorProfileModel>();
            list = await _clinicvendorprofile.GetAllClinicVendorProfileDetails();

            return Ok(list);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> ClinicProfileDetails_InsertUpdate([FromBody] ClinicVendorProfileModel item)
        {
            ClinicVendorProfileModel test = new ClinicVendorProfileModel();

            var result = await _clinicvendorprofile.ClinicProfileDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Profile Added Successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Profile updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClinicDoctorDetails_InsertUpdate(ClinicDoctorModel item)
        {
            ClinicDoctorModel test = new ClinicDoctorModel();
            var result = await _clinicvendorprofile.ClinicDoctorDetails_InsertUpdate(item);
            return Ok(result);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClinicDoctorsDetailsByClinicVendorID(int ClinicVendorID)
        {
            List<ClinicDoctorModel> item = new List<ClinicDoctorModel>();
            if (ClinicVendorID > 0)
            {
                item = await _clinicvendorprofile.GetClinicDoctorsDetailsByClinicVendorID(ClinicVendorID);
            }

            return Ok(item);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetClinicDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {

            var result = await _clinicvendorprofile.SetClinicDoctorSlots(ClinicDoctorID, ClinicVendorID, Date, item);

            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetClinicDoctorSlotsByDateandID(int ClinicDoctorID, DateTime Date)
        {
            List<ClinicSlotDateModel> result = new List<ClinicSlotDateModel>();
            //List<slots> res = new List<slots>();

            result = await _clinicvendorprofile.GetClinicDoctorSlotsByDateandID(ClinicDoctorID, Date);
            return Ok(result);
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> SetClinicVisitDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {

            var result = await _clinicvendorprofile.SetClinicVisitDoctorSlots(ClinicDoctorID, ClinicVendorID, Date, item);

            return Ok(result);
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> GetClinicVisitDoctorSlotsByDateandID(int ClinicDoctorID, DateTime Date)
        {
            List<ClinicSlotDateModel> result = new List<ClinicSlotDateModel>();
            //List<slots> res = new List<slots>();

            result = await _clinicvendorprofile.GetClinicVisitDoctorSlotsByDateandID(ClinicDoctorID, Date);
            return Ok(result);
        }

    }
}
