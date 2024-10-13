using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.Doctors;
using Zyael_Models.Masters;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
     public class SymptomsController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Symptoms _symptoms;
        public IConfiguration config;

        public SymptomsController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _symptoms = new Symptoms(httpContextAccessor, config);
            this.config = config;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetSymptoms(string SymptomTitle,[FromBody] List<symptomslist> item)
        {
           
            var result = await _symptoms.SetSymptoms(SymptomTitle,item);

            return Ok(result);
        }



        [HttpPost("[action]")]
        public async Task<IActionResult>SymptomImageUpload(symptomsImage img)
        {
            SymptomsModel test = new SymptomsModel();
            if (img.SymptomProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "SymptomProfileImageUpload" + "/" + "SymptomProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(img.SymptomProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(img.SymptomProfileImage.ContentDisposition).Size;
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
                        "SymptomProfileImageUpload" + "/",
                        FileGuid + extension);
                    img.SymptomProfileImagePath = "/" + "SymptomProfileImage" + "/" + FileGuid + extension;
                    img.SymptomProfileImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await img.SymptomProfileImage.CopyToAsync(stream);
                    }
                    img.SymptomProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    img.SymptomProfileImageName = "";
                }
            }


            var result = await _symptoms.SymptomImageUpload(img);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSymptoms()
        {
            List<symptomslist> item = new List<symptomslist>();
          
                item = await _symptoms.GetSymptoms();
           

            return Ok(item);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSymptomsdetailsByTitle(string SymptomTitle)
        {
            List<symptomslist> item = new List<symptomslist>();
           
                item = await _symptoms.GetSymptoms(SymptomTitle);
            

            return Ok(item);
        }


    }
}
