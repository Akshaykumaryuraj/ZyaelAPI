using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using Zyael_Models.Doctors;
using Zyael_Models.Logins;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserAppointmentController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public UserAppointment _userappointment;


        public UserAppointmentController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userappointment = new UserAppointment(httpContextAccessor, config);
        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetUserAppointment([FromBody] UserAppointmentScheduleModel app_dels)
        {
            int UserRandomID = new Random().Next(100000, 999999);

            var result = await _userappointment.SetUserAppointment(app_dels, UserRandomID);

            return Ok(result);
        }



        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetUserHospitalAppointment([FromBody] UserHospitalAppointmentModel app_dels)
        {
            int UserRandomID = new Random().Next(100000, 999999);

            var result = await _userappointment.SetUserHospitalAppointment(app_dels, UserRandomID);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetUserClinicAppointment([FromBody] UserClinicAppointmentModel app_dels)
        {
            int UserRandomID = new Random().Next(100000, 999999);

            var result = await _userappointment.SetUserClinicAppointment(app_dels, UserRandomID);

            return Ok(result);
        }





        //[HttpPost("[action]")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Setterms([FromBody] string value)
        //{
        //    int UserRandomID = new Random().Next(100000, 999999);

        //    return Ok();
        //}

        [HttpPost("upload")]
        public async Task<IActionResult> UploadHtmlFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            var result = await _userappointment.UploadHtmlFile(file);

             file.OpenReadStream();
            // Process the uploaded file (e.g., save it to disk or perform other actions)
            // You can access the file content using 'file.OpenReadStream()'

            // Return an appropriate response (e.g., 200 OK)
            return Ok(result);



        }
        [HttpGet("[action]")]
        public IActionResult PrivacyTestPolicy()
        {
            var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "UserProfileImageUpload" + "/" + "UserProfileImage" + "/";
            
            return Ok(samplefilepath);

        }


        [HttpGet("[action]")]
        public IActionResult PrivacyPolicy()
        {
            var staticPage = PhysicalFile(System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "Terms-Conditions\\terms.html"), "text/html");
            return staticPage;
        }




        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAppointmentByUserID(int UserID)
        {
            List<UserAppointmentScheduleModel> result = new List<UserAppointmentScheduleModel>();

            result = await _userappointment.GetUserAppointmentByUserID(UserID);
            DateTime dt = DateTime.Now;
            foreach (UserAppointmentScheduleModel model in result)
            {
                if (dt.Date == model.Date)
                {
                    model.Status = "Today";
                }
                else
                if(dt.Date > model.Date)
                {
                    model.Status = "Completed";

                }
                else
                    if(dt.Date < model.Date)
                {
                    model.Status = "Upcoming";
                }
            }
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserHospitalAppointmentByUserID(int UserID)
        {
            List<UserHospitalAppointmentModel> result = new List<UserHospitalAppointmentModel>();

            result = await _userappointment.GetUserHospitalAppointmentByUserID(UserID);
            DateTime dt = DateTime.Now;
            foreach (UserHospitalAppointmentModel model in result)
            {
                if (dt.Date == model.Date)
                {
                    model.Status = "Today";
                }
                else
                if (dt.Date > model.Date)
                {
                    model.Status = "Completed";

                }
                else
                    if (dt.Date < model.Date)
                {
                    model.Status = "Upcoming";
                }
            }
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserClinicAppointmentByUserID(int UserID)
        {
            List<UserClinicAppointmentModel> result = new List<UserClinicAppointmentModel>();

            result = await _userappointment.GetUserClinicAppointmentByUserID(UserID);
            DateTime dt = DateTime.Now;
            foreach (UserClinicAppointmentModel model in result)
            {
                if (dt.Date == model.Date)
                {
                    model.Status = "Today";
                }
                else
                if (dt.Date > model.Date)
                {
                    model.Status = "Completed";

                }
                else
                    if (dt.Date < model.Date)
                {
                    model.Status = "Upcoming";
                }
            }
            return Ok(result);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<IActionResult> UserCancelAppointmentDetails_InsertUpdate([FromBody] UserCancelAppointmentModel item)
        {
            UserCancelAppointmentModel test = new UserCancelAppointmentModel();

            var result = await _userappointment.UserCancelAppointmentDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Appointment Cancelled!";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Already Apointment has been cancelled";
                return Ok(test);

            }
            return Ok(result);
        }


    }
}
