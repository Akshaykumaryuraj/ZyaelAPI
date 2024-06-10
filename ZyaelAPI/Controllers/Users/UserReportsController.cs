using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReportsController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public UserReports _userreports;


        public UserReportsController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userreports = new UserReports(httpContextAccessor, config);
        }

    
    }
}
