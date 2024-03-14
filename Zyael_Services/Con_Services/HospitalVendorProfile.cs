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

namespace Zyael_Services.Con_Services
{
    public class HospitalVendorProfile
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public HospitalVendorProfileDAL _hospitalvendorprofiledal;
        public HospitalVendorProfile(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _hospitalvendorprofiledal = new HospitalVendorProfileDAL(httpContextAccessor, config);
        }
        public async Task<List<HospitalVendorProfileModel>> GetAllHospitalVendorProfileDetails()
        {
            try
            {
                var result = await _hospitalvendorprofiledal.GetAllHospitalVendorProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
