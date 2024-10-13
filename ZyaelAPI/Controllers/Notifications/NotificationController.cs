using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.Hospitals;
using Zyael_Models.Notifications;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;
using Zyael_Services.Con_Services.Notifications;
using static System.Net.WebRequestMethods;

namespace ZyaelAPI.Controllers.Notifications
{
    [Route("api/[controller]")]
    [ApiController]
     public class NotificationController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Notification _notifications;
        public IConfiguration config;

        public NotificationController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _notifications = new Notification(httpContextAccessor, config);
            this.config = config;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> NotificationDetails_InsertUpdate(NotificationModel item)
        {
            NotificationModel test = new NotificationModel();


            if (item.NotificationImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "NotificationImageUpload" + "/" + "Notifications" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.NotificationImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.NotificationImage.ContentDisposition).Size;
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
                        "notificationimageupload" + "/",
                        FileGuid + extension);
                    item.NotificationImagePath = "/" + "NotificationImage" + "/" + FileGuid + extension;
                    item.NotificationImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.NotificationImage.CopyToAsync(stream);
                    }
                    item.NotificationImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.NotificationImageName = "";
                }
            }

            var result = await _notifications.NotificationDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Notification Uploaded Successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Notification updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllNotificationsDetails()
        {
            List<NotificationModel> list = new List<NotificationModel>();
            list = await _notifications.GetAllNotificationsDetails();

            return Ok(list);

        }


    }
}
