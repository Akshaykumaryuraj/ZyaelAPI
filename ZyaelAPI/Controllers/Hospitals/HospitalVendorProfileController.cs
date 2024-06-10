using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.Hospitals;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Hospitals
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalVendorProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public HospitalVendorProfile _hospitalvendorprofile;


        public HospitalVendorProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _hospitalvendorprofile = new HospitalVendorProfile(httpContextAccessor, config);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllHospitalVendorProfileDetails()
        {
            List<HospitalVendorProfileModel> list = new List<HospitalVendorProfileModel>();
            list = await _hospitalvendorprofile.GetAllHospitalVendorProfileDetails();

            return Ok(list);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> HospitalProfileDetails_InsertUpdate([FromBody] HospitalVendorProfileModel item)
        {
            HospitalVendorProfileModel test = new HospitalVendorProfileModel();


            //if (item.HospitalProfileImage != null)
            //{
            //    try
            //    {
            //        var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "HospitalProfileImageUpload" + "/" + "HospitalProfileImage" + "/";
            //        var fileName = ContentDispositionHeaderValue.Parse(item.HospitalProfileImage.ContentDisposition).FileName;
            //        var filesize = ContentDispositionHeaderValue.Parse(item.HospitalProfileImage.ContentDisposition).Size;
            //        fileName = fileName.Contains("\\")
            //            ? fileName.Trim('"').Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
            //            : fileName.Trim('"');
            //        if (!Directory.Exists(samplefilepath))
            //        {
            //            Directory.CreateDirectory(samplefilepath);
            //        }
            //        var extension = Path.GetExtension(fileName);
            //        var FileGuid = Guid.NewGuid();
            //        var fullFilePath = Path.Combine(
            //            samplefilepath + "/",
            //            FileGuid + extension);
            //        item.HospitalProfileImagePath = "/" + "HospitalProfileImage" + "/" + FileGuid + extension;
            //        item.HospitalProfileImageName = fileName;
            //        using (var stream = new FileStream(fullFilePath, FileMode.Create))
            //        {
            //            await item.HospitalProfileImage.CopyToAsync(stream);
            //        }
            //        item.HospitalProfileImagePath = fullFilePath;
            //    }
            //    catch (Exception ex)
            //    {
            //        item.HospitalProfileImageName = "";
            //    }
            //}

            var result = await _hospitalvendorprofile.HospitalProfileDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Profile Added Successfully";
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
