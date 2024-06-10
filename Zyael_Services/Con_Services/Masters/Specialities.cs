using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Hospital;
using Zyael_DAL.Logins;
using Zyael_DAL.Masters;
using Zyael_DAL.Users;
using Zyael_Models.Hospitals;
using Zyael_Models.Masters;
using Zyael_Models.Users;

namespace Zyael_Services.Con_Services.Masters
{
    public class Specialities
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public SpecialitiesDAl _specialitiesdal;
        public Specialities(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _specialitiesdal = new SpecialitiesDAl(httpContextAccessor, config);
        }
        public async Task<SpecialitiesModel> SpecialitiesDetailsAdd(int SpecialityID)
        {
            try
            {
                var result = await _specialitiesdal.SpecialitiesDetailsAdd(SpecialityID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> SpecialitiesDetails_InsertUpdate(SpecialitiesModel item)
        {
            try
            {
                var result = await _specialitiesdal.SpecialitiesDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<SpecialitiesModel>> GetAllSpecialitiesDetails()
        {
            try
            {
                var result = await _specialitiesdal.GetAllSpecialitiesDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      
    }
}
