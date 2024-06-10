using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Doctors;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFeedbackController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public UserFeedback _userfeedback;
        public IConfiguration config;

        public UserFeedbackController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userfeedback = new UserFeedback(httpContextAccessor, config);
            this.config = config;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> UserFeedbackDetails_InsertUpdate([FromBody]UserFeedbackModel item)
        {
            UserFeedbackModel test = new UserFeedbackModel();

            var result = await _userfeedback.UserFeedbackDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Thanks for Feedback!";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Your Feedback Under Review,updated sortly!";
                return Ok(test);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserFeedbackDetails()
        {
            List<UserFeedbackModel> list = new List<UserFeedbackModel>();
            list = await _userfeedback.GetAllUserFeedbackDetails();

            return Ok(list);

        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserFeedbackByDoctorID(int DoctorID)
        {
            List<UserFeedbackModel> item = new List<UserFeedbackModel>();
            if (DoctorID > 0)
            {
                item = await _userfeedback.GetUserFeedbackByDoctorID(DoctorID);
            }

            return Ok(item);
        }


    }
}
