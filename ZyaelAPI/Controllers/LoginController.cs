using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zyael_Models;
using Zyael_Services;

namespace ZyaelAPI.Controllers
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
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _login = new Login(httpContextAccessor,config);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {

            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(500);
              
            }
            VillaDTO.id = VillaStore.GetVillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.GetVillaList.Add(villaDTO);

            return Ok(villaDTO);
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
