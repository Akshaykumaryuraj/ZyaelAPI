using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Hospital;
using Zyael_DAL.HospitalUserProfile;
using Zyael_Models.Hospitals;

namespace Zyael_Services
{
    public class HospitalUserProfile
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public HospitalUserProfileDAL _hospitaluserprofiledal;
        public HospitalUserProfile(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _hospitaluserprofiledal = new HospitalUserProfileDAL(httpContextAccessor, config);
        }
        public async Task<List<HospitalUserProfileModel>> GetAllHospitalUserProfileDetails()
        {
            try
            {
                var result = await _hospitaluserprofiledal.GetAllHospitalUserProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
