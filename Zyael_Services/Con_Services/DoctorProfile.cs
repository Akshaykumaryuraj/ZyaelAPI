using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.PharmacyDAL;
using Zyael_Models.Doctors;
using Zyael_Models.Pharmacy;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        public async Task<List<DoctorProfileModel>> GetAllDoctorsProfileDetails()
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

        public async Task<ConsultationSlotModel> SetDoctorSlots(int DoctorID, DateTime Date, [FromBody] List<slots> item)
        {
            try
            {
                var result = await _doctorprofiledal.SetDoctorSlots(DoctorID, Date, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ConsultationSlotModel>> GetAvailableSlots(int DoctorID)
        {
            try
            {
                var result = await _doctorprofiledal.GetAvailableSlots(DoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public async Task<List<ConsultationSlotDateModel>> GetDoctorSlotsByDateandID([FromBody] int DoctorID, [FromBody] DateTime Date)
        {
            try
            {
                var result = await _doctorprofiledal.GetDoctorSlotsByDateandID(DoctorID, Date);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DoctorProfileDetails_InsertUpdate(DoctorProfileModel item, List<achievements> achievements)
        {
            {
                try
                {
                    var result = await _doctorprofiledal.DoctorProfileDetails_InsertUpdate(item, achievements);
                    return result;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        public async Task<List<achievements>> GetDoctorAchievementsDetailsByID(int DoctorID)
        {
            try
            {
                var result = await _doctorprofiledal.GetDoctorAchievementsDetailsByID(DoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

