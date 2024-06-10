using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Admins;
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Admin;
using Zyael_Services.Con_Services.InternalDoctor;

namespace ZyaelAPI.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Admin _admin;


        public AdminController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _admin = new Admin(httpContextAccessor, config);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ZyaelPromiseDetails_InsertUpdate(Zyael_PromiseModel item)
        {
            Zyael_PromiseModel test = new Zyael_PromiseModel();
            var result = await _admin.ZyaelPromiseDetails_InsertUpdate(item);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetZyaelPromiseDetails(int ZyaelPID)
        {
            Zyael_PromiseModel item = new Zyael_PromiseModel();
            if (ZyaelPID > 0)
            {
                item = await _admin.GetZyaelPromiseDetails(ZyaelPID);

                item.ZyaelPID = ZyaelPID;
            }

            return Ok(item);

        }

    }
}
