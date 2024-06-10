using Microsoft.AspNetCore.Mvc;
using Zyael_Models.DiagnosticLabs;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.DiagnosticLabs
{
    [Route("api/[controller]")]
    public class DiagnosticLabProfileController : Controller
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public DiagnosticLabProfile _diagnosticLabprofile;


        public DiagnosticLabProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _diagnosticLabprofile = new DiagnosticLabProfile(httpContextAccessor, config);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiagnosticProfileDetails()
        {
            List<DiagnosticLabModel> list = new List<DiagnosticLabModel>();
            list = await _diagnosticLabprofile.GetAllDiagnosticProfileDetails();

            return Ok(list);

        }


        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DiagnosticLabProfileDetailsByID(int DLVPID)
        {
            DiagnosticLabModel item = new DiagnosticLabModel();
            if (DLVPID > 0)
            {
                item = await _diagnosticLabprofile.DiagnosticLabProfileDetailsByID(DLVPID);

                item.DLVPID = DLVPID;
            }

            return Ok(item);

        }
    }
}
