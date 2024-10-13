using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.Hospitals;
using Zyael_Models.Masters;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Specialities _specialities;
        public IConfiguration config;

        public SpecialitiesController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _specialities = new Specialities(httpContextAccessor, config);
            this.config = config;
        }
        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SpecialitiesDetailsAdd(int SpecialityID)
        {
            SpecialitiesModel item = new SpecialitiesModel();
            if (SpecialityID > 0)
            {
                item = await _specialities.SpecialitiesDetailsAdd(SpecialityID);

                item.SpecialityID = SpecialityID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> SpecialitiesDetails_InsertUpdate(SpecialitiesModel item)
        {
            SpecialitiesModel test = new SpecialitiesModel();
            if (item.SpecialityProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "SpecialityProfileImageUpload" + "/" + "SpecialityProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.SpecialityProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.SpecialityProfileImage.ContentDisposition).Size;
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
                        "SpecialityProfileImageUpload" + "/",
                        FileGuid + extension);
                    item.SpecialityProfileImagePath = "/" + "SpecialityProfileImage" + "/" + FileGuid + extension;
                    item.SpecialityProfileImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.SpecialityProfileImage.CopyToAsync(stream);
                    }
                    item.SpecialityProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.SpecialityProfileImageName = "";
                }
            }


            var result = await _specialities.SpecialitiesDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Uploaded successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialitiesDetails()
        {
            List<SpecialitiesModel> list = new List<SpecialitiesModel>();
            list = await _specialities.GetAllSpecialitiesDetails();

            return Ok(list);

        }


       

    }
}
