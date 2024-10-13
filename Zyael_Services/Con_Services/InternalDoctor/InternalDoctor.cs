using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Clinic;
using Zyael_DAL.Doctors;
using Zyael_DAL.HospitalUserProfile;
using Zyael_DAL.InternalDoctor;
using Zyael_DAL.Users;
using Zyael_Models.Clinics;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Users;

namespace Zyael_Services.Con_Services.InternalDoctor
{
      public class InternalDoctor
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public InternalDoctorDAL _internaldoctordal;
        public InternalDoctor(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _internaldoctordal = new InternalDoctorDAL(httpContextAccessor, config);
        }


        public async Task<int> InternalDoctorDetails_InsertUpdate(InternalDoctorModel item)
        {
            try
            {
                var result = await _internaldoctordal.InternalDoctorDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<List<InternalDoctorModel>> GetInternalDoctorsDetailsByHospitalVendorID(int HospitalVendorID)
        {
            try
            {
                var result = await _internaldoctordal.GetInternalDoctorsDetailsByHospitalVendorID(HospitalVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<ShiftSlotModel> SetInternalDoctorSlots(int IDoctorID,int HospitalVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            try
            {
                var result = await _internaldoctordal.SetInternalDoctorSlots(IDoctorID, HospitalVendorID, Date, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ShiftSlotModel>> GetInternalDoctorAvailableSlots(int IDoctorID)
        {
            try
            {
                var result = await _internaldoctordal.GetInternalDoctorAvailableSlots(IDoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ShiftSlotDateModel>> GetInternalDoctorSlotsByDateandID([FromBody] int IDoctorID, [FromBody] DateTime Date)
        {
            try
            {
                var result = await _internaldoctordal.GetInternalDoctorSlotsByDateandID(IDoctorID, Date);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InternalDoctorProfileImageDetails_InsertUpdate(InternalDoctorProfileImageModel item)
        {
            try
            {
                var result = await _internaldoctordal.InternalDoctorProfileImageDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
