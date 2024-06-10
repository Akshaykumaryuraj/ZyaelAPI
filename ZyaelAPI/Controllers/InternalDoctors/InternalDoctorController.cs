using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.InternalDoctor;

namespace ZyaelAPI.Controllers.InternalDoctors
{
    [Route("api/[controller]")]
    [ApiController]
   public class InternalDoctorController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public InternalDoctor _internaldoctor;


        public InternalDoctorController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _internaldoctor = new InternalDoctor(httpContextAccessor, config);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InternalDoctorDetails_InsertUpdate(InternalDoctorModel item)
        {
            InternalDoctorModel test = new InternalDoctorModel();
            var result = await _internaldoctor.InternalDoctorDetails_InsertUpdate(item);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInternalDoctorsDetailsByHospitalVendorID(int HospitalVendorID)
        {
            List<InternalDoctorModel> item = new List<InternalDoctorModel>();
            if (HospitalVendorID > 0)
            {
                item = await _internaldoctor.GetInternalDoctorsDetailsByHospitalVendorID(HospitalVendorID);
            }

            return Ok(item);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetInternalDoctorSlots(int IDoctorID,int HospitalVendorID, DateTime Date, [FromBody] List<Shits> item)
        {

            var result = await _internaldoctor.SetInternalDoctorSlots(IDoctorID, HospitalVendorID, Date, item);

            return Ok(result);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInternalDoctorAvailableSlots(int IDoctorID)
        {
            List<ShiftSlotModel> item = new List<ShiftSlotModel>();
            if (IDoctorID > 0)
            {
                item = await _internaldoctor.GetInternalDoctorAvailableSlots(IDoctorID);
            }

            return Ok(item);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetInternalDoctorSlotsByDateandID(int IDoctorID, DateTime Date)
        {
            List<ShiftSlotDateModel> result = new List<ShiftSlotDateModel>();
            //List<slots> res = new List<slots>();

            result = await _internaldoctor.GetInternalDoctorSlotsByDateandID(IDoctorID, Date);
            return Ok(result);
        }

    }
}
