using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http.Headers;
using System.Reflection;
using Zyael_Models.Logins;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        readonly IWebHostEnvironment _webhostingEnvironment;
        public UserProfie _userprofile;
        public IConfiguration config;

        public UserProfileController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config, IWebHostEnvironment webhostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userprofile = new UserProfie(httpContextAccessor, config);
            this.config = config;
            _webhostingEnvironment = webhostingEnvironment;
        }


        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserProfileDetailsAdd(int UserPID)
        {
            UserProfileModel item = new UserProfileModel();
            if (UserPID > 0)
            {
                item = await _userprofile.UserProfileDetailsAdd(UserPID);

                item.UserPID = UserPID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> UserProfileDetails_InsertUpdate([FromBody] UserProfileModel item)
        {
            UserProfileModel test = new UserProfileModel();


            //if (item.UserProfileImage != null)
            //{
            //    try
            //    {
            //        var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/"+"UserProfileImageUpload" +"/" + "UserProfileImage" + "/";
            //        var fileName = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).FileName;
            //        var filesize = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).Size;
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
            //        item.UserImagePath = "/" + "UserImage" + "/" + FileGuid + extension;
            //        item.UserImageName = fileName;
            //        using (var stream = new FileStream(fullFilePath, FileMode.Create))
            //        {
            //            await item.UserProfileImage.CopyToAsync(stream);
            //        }
            //        item.UserImagePath = fullFilePath;
            //    }
            //    catch (Exception ex)
            //    {
            //        item.UserImageName = "";
            //    }
            //}

            var result = await _userprofile.UserProfileDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "User Profile Uploaded successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "User Profile updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

    

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationtoken)
        {
            var result = await WriteFile(file);
            return Ok(result);
        }

        private async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
            }
            return filename;
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<IActionResult> UserProfileImage_Upload(UserProfile_Upload item)
        {
            UserProfile_Upload test = new UserProfile_Upload();


            //if (item.UserProfileImage != null)
            //{
            //    try
            //    {
            //        var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "UserProfileImageUpload" + "/" + "UserProfileImage" + "/";
            //        var fileName = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).FileName;
            //        var filesize = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).Size;
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
            //        item.UserImagePath = "/" + "UserProfileImage" + "/" + FileGuid + extension;
            //        item.UserImageName = fileName;
            //        using (var stream = new FileStream(fullFilePath, FileMode.Create))
            //        {
            //            await item.UserProfileImage.CopyToAsync(stream);
            //        }
            //        item.UserImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;

            //    }
            //    catch (Exception ex)
            //    {
            //        item.UserImageName = "";
            //    }
            //}
            if (item.UserProfileImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "UserProfileImageUpload" + "/" + "UserProfileImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.UserProfileImage.ContentDisposition).Size;
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
                        "UserProfileImageUpload" + "/",
                        FileGuid + extension);
                    item.UserImagePath = "/" + "DoctorProfileImage" + "/" + FileGuid + extension;
                    item.UserImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.UserProfileImage.CopyToAsync(stream);
                    }
                    item.UserImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.UserImageName = "";
                }
            }
            var result = await _userprofile.UserProfile_Upload(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Profile  Image uploaded successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Profile Image updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }


        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UserProfileImageUpload\\UserProfileImage", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            //return Content(File.ReadAllText("somefile.html"));
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }
    }
}
