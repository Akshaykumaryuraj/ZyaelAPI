using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Hospitals;
using Zyael_Models.Masters;
using Zyael_Models.Users;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public Specialities _specialities;
        public IConfiguration config;

        public SpecialitiesController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _specialities = new Specialities(httpContextAccessor, config);
            this.config = config;
        }
        [HttpGet("id")]
        //[Route("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SpecialitiesDetailsAdd(int SpecialityID)
        {
            SpecialitiesModel item = new SpecialitiesModel();
            if (SpecialityID > 0)
            {
                item = await _specialities.SpecialitiesDetailsAdd(SpecialityID);

                item.SpecialityID = SpecialityID;
            }

            return Ok(item);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> SpecialitiesDetails_InsertUpdate(SpecialitiesModel item)
        {
            SpecialitiesModel test = new SpecialitiesModel();

            var result = await _specialities.SpecialitiesDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "inserted successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialitiesDetails()
        {
            List<SpecialitiesModel> list = new List<SpecialitiesModel>();
            list = await _specialities.GetAllSpecialitiesDetails();

            return Ok(list);

        }

    }
}
