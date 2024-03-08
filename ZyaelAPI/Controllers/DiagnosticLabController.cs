using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Hospitals;
using Zyael_Services;

namespace ZyaelAPI.Controllers
{
    [Route("api/[controller]")]
    public class DiagnosticLabController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public DiagnosticLab _diagnosticLab;


        public DiagnosticLabController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _diagnosticLab = new DiagnosticLab(httpContextAccessor, config);
        }


        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DiagnosticLabCredentialAdd(int DiagnosticLabVendorID)
        {
            DiagnosticLabModel item = new DiagnosticLabModel();
            if (DiagnosticLabVendorID > 0)
            {
                item = await _diagnosticLab.DiagnosticLabCredentialAdd(DiagnosticLabVendorID);

                item.DiagnosticLabVendorID = DiagnosticLabVendorID;
            }

            return Ok(item);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> DiagnosticLabCredentialDetails_InsertUpdate(DiagnosticLabModel item)
        {
            var result = await _diagnosticLab.DiagnosticLabCredentialDetails_InsertUpdate(item);

            if (result == 0)
            {

                return Ok(result);


            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> DiagnosticLabCredentialDetailsDelete(int DiagnosticLabVendorID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _diagnosticLab.DiagnosticLabCredentialDetailsDelete(DiagnosticLabVendorID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }
    }
}
