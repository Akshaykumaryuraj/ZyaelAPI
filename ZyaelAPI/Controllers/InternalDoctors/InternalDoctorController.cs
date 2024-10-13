using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using Zyael_Models.Clinics;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.InternalDoctor;

namespace ZyaelAPI.Controllers.InternalDoctors
{
    [Route("api/[controller]")]
    [ApiController]
   public class InternalDoctorController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public InternalDoctor _internaldoctor;


        public InternalDoctorController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _internaldoctor = new InternalDoctor(httpContextAccessor, config);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InternalDoctorDetails_InsertUpdate(InternalDoctorModel item)
        {
            InternalDoctorModel test = new InternalDoctorModel();
            var result = await _internaldoctor.InternalDoctorDetails_InsertUpdate(item);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInternalDoctorsDetailsByHospitalVendorID(int HospitalVendorID)
        {
            List<InternalDoctorModel> item = new List<InternalDoctorModel>();
            if (HospitalVendorID > 0)
            {
                item = await _internaldoctor.GetInternalDoctorsDetailsByHospitalVendorID(HospitalVendorID);
            }

            return Ok(item);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetInternalDoctorSlots(int IDoctorID,int HospitalVendorID, DateTime Date, [FromBody] List<Shits> item)
        {

            var result = await _internaldoctor.SetInternalDoctorSlots(IDoctorID, HospitalVendorID, Date, item);

            return Ok(result);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInternalDoctorAvailableSlots(int IDoctorID)
        {
            List<ShiftSlotModel> item = new List<ShiftSlotModel>();
            if (IDoctorID > 0)
            {
                item = await _internaldoctor.GetInternalDoctorAvailableSlots(IDoctorID);
            }

            return Ok(item);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetInternalDoctorSlotsByDateandID(int IDoctorID, DateTime Date)
        {
            List<ShiftSlotDateModel> result = new List<ShiftSlotDateModel>();
            //List<slots> res = new List<slots>();
            result = await _internaldoctor.GetInternalDoctorSlotsByDateandID(IDoctorID, Date);
            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> InternalDoctorProfileImageDetails_InsertUpdate(InternalDoctorProfileImageModel item)
        {
            InternalDoctorProfileImageModel test = new InternalDoctorProfileImageModel();


            if (item.IDoctorProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "IDoctorProfileImageUpload" + "/" + "IDoctorProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.IDoctorProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.IDoctorProfileImage.ContentDisposition).Size;
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
                        "IDoctorProfileImageUpload" + "/",
                        FileGuid + extension);
                    item.IDoctorProfileImagePath = "/" + "IDoctorProfileImage" + "/" + FileGuid + extension;
                    item.IDoctorProfileImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.IDoctorProfileImage.CopyToAsync(stream);
                    }
                    item.IDoctorProfileImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.IDoctorProfileImageName = "";
                }
            }

            var result = await _internaldoctor.InternalDoctorProfileImageDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Internal doctor Profile Image Uploaded Successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Internal doctor Profile Image updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

    }
}
