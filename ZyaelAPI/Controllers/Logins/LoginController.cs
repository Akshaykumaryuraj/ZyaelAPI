using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zyael_Models;
using Zyael_Models.Logins;
using Zyael_Services;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Logins
{
    //[Route("api/Login")]

    //[Route("api/Controller")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Login _login;


        public LoginController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _login = new Login(httpContextAccessor, config);
        }

        [Route("api/[controller]/[action]")]

        [HttpPost]
        public async Task<IActionResult> SetAdminLogin(LoginModel item)
        {
            LoginModel result = new LoginModel();
            result = await _login.SetAdminLogin(item);

            if (result.returnId != -1)
            {
                result.message = "Login success";
                return Ok(result);


            }
            else
            {
                return BadRequest("not found");

            }

        }




        [Route("api/[controller]/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> SetHositalVendorLogin(HospitalsVendorsLoginModel item)
        {
            HospitalsVendorsLoginModel result = new HospitalsVendorsLoginModel();
            result = await _login.SetHositalVendorLogin(item);

            if (result.returnId != -1)
            {
                return Ok(result);


            }
            else
            {
                return BadRequest("not found");

            }
        }



        [Route("api/[controller]/[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.GetVillaList);
        }



        private IActionResult Json(int returnId)
        {
            throw new NotImplementedException();




        }


    }
}

