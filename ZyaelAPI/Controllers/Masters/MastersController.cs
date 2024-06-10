using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Masters;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public MastersCollections _masters;
        public IConfiguration config;

        public MastersController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _masters = new MastersCollections(httpContextAccessor, config);
            this.config = config;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllergies()
        {
            List<MastersModel> list = new List<MastersModel>();
            list = await _masters.GetAllergies();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCurrentMedications()
        {
            List<CurrentMedicationModel> list = new List<CurrentMedicationModel>();
            list = await _masters.GetAllCurrentMedications();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPastMedications()
        {
            List<PastMedicationModel> list = new List<PastMedicationModel>();
            list = await _masters.GetAllPastMedications();

            return Ok(list);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllChronicMedications()
        {
            List<ChronicMedicationModel> list = new List<ChronicMedicationModel>();
            list = await _masters.GetAllChronicMedications();

            return Ok(list);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInjuries()
        {
            List<InjuriesModel> list = new List<InjuriesModel>();
            list = await _masters.GetAllInjuries();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSurgeries()
        {
            List<SurgeriesModel> list = new List<SurgeriesModel>();
            list = await _masters.GetAllSurgeries();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSmokingHabits()
        {
            List<SmokingHabitsModel> list = new List<SmokingHabitsModel>();
            list = await _masters.GetSmokingHabits();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlcoholHabits()
        {
            List<AlcoholHabitsModel> list = new List<AlcoholHabitsModel>();
            list = await _masters.GetAlcoholHabits();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBloodGroup()
        {
            List<BloodGroupModel> list = new List<BloodGroupModel>();
            list = await _masters.GetBloodGroup();

            return Ok(list);

        }

    }
}
