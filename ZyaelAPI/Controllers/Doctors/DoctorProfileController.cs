using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Zyael_Models.Doctors;
using Zyael_Models.Notifications;
using Zyael_Models.Pharmacy;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Notifications;

namespace ZyaelAPI.Controllers.Doctors
{
    [Route("api/[controller]")]
    public class DoctorProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public DoctorProfile _doctorprofile;


        public DoctorProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _doctorprofile = new DoctorProfile(httpContextAccessor, config);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsProfileDetails()
        {
            List<DoctorProfileModel> list = new List<DoctorProfileModel>();
            List<achievements> res = new List<achievements>();

            list = await _doctorprofile.GetAllDoctorsProfileDetails();


            return Ok(list);

        }

        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorsProfileDetails(int DoctorPId)
        {
            DoctorProfileModel item = new DoctorProfileModel();
            if (DoctorPId > 0)
            {
                item = await _doctorprofile.GetDoctorsProfileDetails(DoctorPId);

                item.DoctorPId = DoctorPId;
            }

            return Ok(item);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SetDoctorSlots(int DoctorID,DateTime Date,[FromBody]List<slots>item)
        {
            
                var result = await _doctorprofile.SetDoctorSlots(DoctorID,Date,item);

            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAvailableSlots(int DoctorID)
        {
            List<ConsultationSlotModel> item = new List<ConsultationSlotModel>();
            if (DoctorID > 0)
            {
                item = await _doctorprofile.GetAvailableSlots(DoctorID);
            }

            return Ok(item);
        }


        


        [HttpPost("[action]")]
        public async Task<IActionResult> GetDoctorSlotsByDateandID(int DoctorID, DateTime Date)
        {
            List<ConsultationSlotDateModel> result = new List<ConsultationSlotDateModel>();
            //List<slots> res = new List<slots>();

            result = await _doctorprofile.GetDoctorSlotsByDateandID(DoctorID, Date);
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> DoctorProfileDetails_InsertUpdate([FromBody] DoctorProfileModel item, List<achievements> achievements)
        {
            DoctorProfileModel test = new DoctorProfileModel();

            //if (item.DoctorProfileImage != null)
            //{
            //    try
            //    {
            //        var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "DoctorProfileImageUpload" + "/" + "DoctorProfileImage" + "/";
            //        var fileName = ContentDispositionHeaderValue.Parse(item.DoctorProfileImage.ContentDisposition).FileName;
            //        var filesize = ContentDispositionHeaderValue.Parse(item.DoctorProfileImage.ContentDisposition).Size;
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
            //            "DoctorProfileImageUpload" + "/",
            //            FileGuid + extension);
            //        item.DoctorProfileImagePath = "/" + "DoctorProfileImage" + "/" + FileGuid + extension;
            //        item.DoctorProfileImageName = fileName;
            //        using (var stream = new FileStream(fullFilePath, FileMode.Create))
            //        {
            //            await img.DoctorProfileImage.CopyToAsync(stream);
            //        }
            //        item.DoctorProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
            //    }
            //    catch (Exception ex)
            //    {
            //        item.DoctorProfileImageName = "";
            //    }
            //}
            var result = await _doctorprofile.DoctorProfileDetails_InsertUpdate(item, achievements);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Profile Added Successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = " Profile updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDoctorAchievementsDetailsByID(int DoctorID)
        {
            List<achievements> result = new List<achievements>();
            //List<slots> res = new List<slots>();

            result = await _doctorprofile.GetDoctorAchievementsDetailsByID(DoctorID);
            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> DoctorProfileImageDetails_InsertUpdate(DoctorProfileImageModel item)
        {
            DoctorProfileImageModel test = new DoctorProfileImageModel();


            if (item.DoctorProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "DoctorProfileImageUpload" + "/" + "DoctorProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.DoctorProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.DoctorProfileImage.ContentDisposition).Size;
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
                        "DoctorProfileImageUpload" + "/",
                        FileGuid + extension);
                    item.DoctorProfileImagePath = "/" + "DoctorProfileImage" + "/" + FileGuid + extension;
                    item.DoctorProfileImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.DoctorProfileImage.CopyToAsync(stream);
                    }
                    item.DoctorProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.DoctorProfileImageName = "";
                }
            }

            var result = await _doctorprofile.DoctorProfileImageDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Doctor Profile Image Uploaded Successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Doctor Profile updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }



    }
}
