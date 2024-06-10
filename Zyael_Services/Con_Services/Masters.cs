using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Masters;
using Zyael_Models.Masters;

namespace Zyael_Services.Con_Services
{
    public class MastersCollections
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public MastersDAl _mastersdal;
        public MastersCollections(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _mastersdal = new MastersDAl(httpContextAccessor, config);
        }


        public async Task<List<MastersModel>> GetAllergies()
        {
            try
            {
                var result = await _mastersdal.GetAllergies();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CurrentMedicationModel>> GetAllCurrentMedications()
        {
            try
            {
                var result = await _mastersdal.GetAllCurrentMedications();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PastMedicationModel>> GetAllPastMedications()
        {
            try
            {
                var result = await _mastersdal.GetAllPastMedications();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ChronicMedicationModel>> GetAllChronicMedications()
        {
            try
            {
                var result = await _mastersdal.GetAllChronicMedications();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<InjuriesModel>> GetAllInjuries()
        {
            try
            {
                var result = await _mastersdal.GetAllInjuries();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<SurgeriesModel>> GetAllSurgeries()
        {
            try
            {
                var result = await _mastersdal.GetAllSurgeries();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<SmokingHabitsModel>> GetSmokingHabits()
        {
            try
            {
                var result = await _mastersdal.GetSmokingHabits();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AlcoholHabitsModel>> GetAlcoholHabits()
        {
            try
            {
                var result = await _mastersdal.GetAlcoholHabits();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BloodGroupModel>> GetBloodGroup()
        {
            try
            {
                var result = await _mastersdal.GetBloodGroup();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
