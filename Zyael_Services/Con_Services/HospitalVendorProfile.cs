using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.Hospital;
using Zyael_DAL.HospitalUserProfile;
using Zyael_DAL.Users;
using Zyael_Models.Doctors;
using Zyael_Models.Hospitals;
using Zyael_Models.Users;

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



        public async Task<int> HospitalProfileDetails_InsertUpdate(HospitalVendorProfileModel item)
        {
            try
            {
                var result = await _hospitalvendorprofiledal.HospitalProfileDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> HospitalVendorProfileImageDetails_InsertUpdate(HospitalVendorProfileImageModel item)
        {
            try
            {
                var result = await _hospitalvendorprofiledal.HospitalVendorProfileImageDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


    }
}
