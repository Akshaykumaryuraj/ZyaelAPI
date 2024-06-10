using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.Hospital;
using Zyael_DAL.Masters;
using Zyael_Models.Doctors;
using Zyael_Models.Hospitals;
using Zyael_Models.Masters;

namespace Zyael_Services.Con_Services
{
    public class DoctorRegistration
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public DoctorRegistrationDAL _doctorregistrationdal;
        public DoctorRegistration(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _doctorregistrationdal = new DoctorRegistrationDAL(httpContextAccessor, config);
        }

        public async Task<DoctorRegistrationModel> DoctorRegistrationCredentialAdd(int DoctorID)
        {
            try
            {
                var result = await _doctorregistrationdal.DoctorRegistrationCredentialAdd(DoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DoctorRegistrationCredentialDetails_InsertUpdate(DoctorRegistrationModel item)
        {
            try
            {
                var result = await _doctorregistrationdal.DoctorRegistrationCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<DoctorRegistrationModel> DoctorRegistrationCredentialDetailsDelete(int DoctorID)
        {
            try
            {
                var result = await _doctorregistrationdal.DoctorRegistrationCredentialDetailsDelete(DoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<DoctorRegistrationModel>> GetAllDoctorsRegistrationCredentialDetails()
        {
            try
            {
                var result = await _doctorregistrationdal.GetAllDoctorsRegistrationCredentialDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DoctorRegistrationModel>> DoctorsDetailsSearchBy(string data)
        {
            try
            {
                var result = await _doctorregistrationdal.DoctorsDetailsSearchBy(data);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ConsultationCategoryModel>> GetAllConsultationCategoryDetails()
        {
            try
            {
                var result = await _doctorregistrationdal.GetAllConsultationCategoryDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ConsultationCategoryModel> GetConsultationCategoryDetailsByID(int CCID)
        {
            try
            {
                var result = await _doctorregistrationdal.GetConsultationCategoryDetailsByID(CCID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
