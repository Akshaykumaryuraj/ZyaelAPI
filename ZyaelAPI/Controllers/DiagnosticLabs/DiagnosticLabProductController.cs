using Microsoft.AspNetCore.Mvc;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.DiagnosticLabs
{
 
        [Route("api/[controller]")]
        public class DiagnosticLabProductController : ControllerBase
        {
            readonly IHttpContextAccessor _httpContextAccessor;
            readonly IHostEnvironment _hostingEnvironment;
            public DiagnosticLabProduct _daignosticlabproduct;


            public DiagnosticLabProductController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
            {
                _hostingEnvironment = hostingEnvironment;
                _httpContextAccessor = httpContextAccessor;
            _daignosticlabproduct = new DiagnosticLabProduct(httpContextAccessor, config);
            }

     }
}
