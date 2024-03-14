
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models;
using Zyael_Models.Logins;
using Zyael_Models.Hospitals;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Hospitals
{

    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Hospital _hospital;


        public HospitalsController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _hospital = new Hospital(httpContextAccessor, config);
        }

        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> HospitalCredentialAdd(int HospitalVendorID)
        {
            HospitalModel item = new HospitalModel();
            if (HospitalVendorID > 0)
            {
                item = await _hospital.HospitalCredentialAdd(HospitalVendorID);

                item.HospitalVendorID = HospitalVendorID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> HospitalCredentialDetails_InsertUpdate(HospitalModel item)
        {
            HospitalModel test = new HospitalModel();

            var result = await _hospital.HospitalCredentialDetails_InsertUpdate(item);

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> HospitalCredentialDetailsDelete(int HospitalVendorID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _hospital.HospitalCredentialDetailsDelete(HospitalVendorID);
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
        public async Task<IActionResult> GetAllHospitalCredentialDetails()
        {
            List<HospitalModel> list = new List<HospitalModel>();
            list = await _hospital.GetAllHospitalCredentialDetails();

            return Ok(list);

        }

    }
}
