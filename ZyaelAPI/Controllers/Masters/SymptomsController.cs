using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Doctors;
using Zyael_Models.Masters;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
     public class SymptomsController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Symptoms _symptoms;
        public IConfiguration config;

        public SymptomsController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _symptoms = new Symptoms(httpContextAccessor, config);
            this.config = config;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetSymptoms(string SymptomTitle,[FromBody] List<symptomslist> item)
        {
            var result = await _symptoms.SetSymptoms(SymptomTitle,item);

            return Ok(result);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSymptoms()
        {
            List<symptomslist> item = new List<symptomslist>();
          
                item = await _symptoms.GetSymptoms();
           

            return Ok(item);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSymptomsdetailsByTitle(string SymptomTitle)
        {
            List<symptomslist> item = new List<symptomslist>();
           
                item = await _symptoms.GetSymptoms(SymptomTitle);
            

            return Ok(item);
        }


    }
}
