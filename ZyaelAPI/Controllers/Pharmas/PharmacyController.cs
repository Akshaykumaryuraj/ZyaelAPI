using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Hospitals;
using Zyael_Models.PharmacyModel;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Pharmas
{
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Pharmacy _pharmacy;


        public PharmacyController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _pharmacy = new Pharmacy(httpContextAccessor, config);
        }



        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PharmacyVendorCredentialAdd(int PVID)
        {
            PharmacyModel item = new PharmacyModel();
            if (PVID > 0)
            {
                item = await _pharmacy.PharmacyVendorCredentialAdd(PVID);

                item.PVID = PVID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> PharmacyVendorCredentialDetails_InsertUpdate(PharmacyModel item)
        {
            PharmacyModel test = new PharmacyModel();

            var result = await _pharmacy.PharmacyVendorCredentialDetails_InsertUpdate(item);

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



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PharmacyVendorCredentialDetailsDelete(int PVID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _pharmacy.PharmacyVendorCredentialDetailsDelete(PVID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPharmacyVendorCredentialDetails()
        {
            List<PharmacyModel> list = new List<PharmacyModel>();
            list = await _pharmacy.GetAllPharmacyVendorCredentialDetails();

            return Ok(list);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPharmacyVendorProfileDetails()
        {
            List<PharmacyModel> list = new List<PharmacyModel>();
            list = await _pharmacy.GetAllPharmacyVendorProfileDetails();

            return Ok(list);

        }
    }

}
