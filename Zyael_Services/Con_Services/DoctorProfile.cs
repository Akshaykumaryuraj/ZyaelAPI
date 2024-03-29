using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_Models.Doctors;

namespace Zyael_Services.Con_Services
{
    public class DoctorProfile
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public DoctorProfileDAL _doctorprofiledal;
        public DoctorProfile(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _doctorprofiledal = new DoctorProfileDAL(httpContextAccessor, config);
        }


        public async Task<List<DoctorRegistrationModel>> GetAllDoctorsProfileDetails()
        {
            try
            {
                var result = await _doctorprofiledal.GetAllDoctorsProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DoctorProfileModel> GetDoctorsProfileDetails(int DoctorPId)
        {
            try
            {
                var result = await _doctorprofiledal.GetDoctorsProfileDetails(DoctorPId);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
