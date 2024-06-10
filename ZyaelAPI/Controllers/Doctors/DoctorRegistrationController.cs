using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Doctors;
using Zyael_Models.Hospitals;
using Zyael_Models.Masters;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Doctors
{
    [Route("api/[controller]")]
    public class DoctorRegistrationController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public DoctorRegistration _doctorRegistration;


        public DoctorRegistrationController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _doctorRegistration = new DoctorRegistration(httpContextAccessor, config);
        }

        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DoctorRegistrationCredentialAdd(int DoctorID)
        {
            DoctorRegistrationModel item = new DoctorRegistrationModel();
            if (DoctorID > 0)
            {
                item = await _doctorRegistration.DoctorRegistrationCredentialAdd(DoctorID);

                item.DoctorID = DoctorID;
            }

            return Ok(item);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> DoctorRegistrationCredentialDetails_InsertUpdate(DoctorRegistrationModel item)
        {
            DoctorRegistrationModel test = new DoctorRegistrationModel();

            var result = await _doctorRegistration.DoctorRegistrationCredentialDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Sigup successful";
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> DoctorRegistrationCredentialDetailsDelete(int DoctorID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _doctorRegistration.DoctorRegistrationCredentialDetailsDelete(DoctorID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsRegistrationCredentialDetails()
        {
            List<DoctorRegistrationModel> list = new List<DoctorRegistrationModel>();
            list = await _doctorRegistration.GetAllDoctorsRegistrationCredentialDetails();

            return Ok(list);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("[action]")]
        public async Task<IActionResult> DoctorsDetailsSearchBy( string data)
        {
            List<DoctorRegistrationModel> result = new List<DoctorRegistrationModel>();

             result = await _doctorRegistration.DoctorsDetailsSearchBy(data);

            
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllConsultationCategoryDetails()
        {
            List<ConsultationCategoryModel> list = new List<ConsultationCategoryModel>();
            list = await _doctorRegistration.GetAllConsultationCategoryDetails();

            return Ok(list);

        }


        [HttpGet("[action]")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetConsultationCategoryDetailsByID(int CCID)
        {
            ConsultationCategoryModel item = new ConsultationCategoryModel();
            if (CCID > 0)
            {
                item = await _doctorRegistration.GetConsultationCategoryDetailsByID(CCID);

                item.CCID = CCID;
            }

            return Ok(item);

        }



    }
}
