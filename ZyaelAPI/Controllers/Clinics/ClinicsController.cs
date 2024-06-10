using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Clinics;
using Zyael_Models.Hospitals;
using Zyael_Services;
using static System.Net.Mime.MediaTypeNames;

namespace ZyaelAPI.Controllers.Clinics
{

    [Route("api/[controller]")]
    public class ClinicsController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Clinic _clinic;


        public ClinicsController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _clinic = new Clinic(httpContextAccessor, config);
        }


        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClinicCredentialAdd(int ClinicVendorID)
        {
            ClinicModel item = new ClinicModel();
            if (ClinicVendorID > 0)
            {
                item = await _clinic.ClinicCredentialAdd(ClinicVendorID);

                item.ClinicVendorID = ClinicVendorID;
            }

            return Ok(item);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClinicCredentialDetails_InsertUpdate(ClinicModel item)
        {
            ClinicModel test = new ClinicModel();

            var result = await _clinic.ClinicCredentialDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Signup successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Credentials details updated successfully";
                return Ok(test);

            }
            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClinicCredentialDetailsDelete(int ClinicVendorID)
        {

            var respose = await _clinic.ClinicCredentialDetailsDelete(ClinicVendorID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }
    }
}
