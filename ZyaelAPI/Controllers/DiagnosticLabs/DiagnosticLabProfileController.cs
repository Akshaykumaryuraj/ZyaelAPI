using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Doctors;
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



        [HttpPost("[action]")]
        public async Task<IActionResult> DiagnosticLabProfileImageDetails_InsertUpdate(DiagnosticLabProfileImageModel item)
        {
            DiagnosticLabProfileImageModel test = new DiagnosticLabProfileImageModel();


            if (item.DiagnosticLabProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "DiagnosticLabProfileImageUpload" + "/" + "DiagnosticLabProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.DiagnosticLabProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.DiagnosticLabProfileImage.ContentDisposition).Size;
                    fileName = fileName.Contains("\\")
                     ? fileName.Trim('"').Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                    : fileName.Trim('"');
                    if (!Directory.Exists(samplefilepath))
                    {
                        Directory.CreateDirectory(samplefilepath);
                    }
                    var extension = Path.GetExtension(fileName);
                    var FileGuid = Guid.NewGuid();
                    var fullFilePath = Path.Combine(
                        "DiagnosticLabProfileImageUpload" + "/",
                        FileGuid + extension);
                    item.DiagnosticLabProfileImagePath = "/" + "DiagnosticLabProfileImage" + "/" + FileGuid + extension;
                    item.DiagnosticLabProfileImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.DiagnosticLabProfileImage.CopyToAsync(stream);
                    }
                    item.DiagnosticLabProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.DiagnosticLabProfileImageName = "";
                }
            }

            var result = await _diagnosticLabprofile.DiagnosticLabProfileImageDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Profile Image Uploaded Successfully";
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

    }
}
