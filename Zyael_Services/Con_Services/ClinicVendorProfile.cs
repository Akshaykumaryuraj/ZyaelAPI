using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Clinic;
using Zyael_DAL.HospitalUserProfile;
using Zyael_DAL.InternalDoctor;
using Zyael_Models.Clinics;
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;

namespace Zyael_Services.Con_Services
{
    public class ClinicVendorProfile
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public ClinicVendorProfileDAL _clinicvendorprofiledal;
        public ClinicVendorProfile(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _clinicvendorprofiledal = new ClinicVendorProfileDAL(httpContextAccessor, config);
        }
        public async Task<List<ClinicVendorProfileModel>> GetAllClinicVendorProfileDetails()
        {
            try
            {
                var result = await _clinicvendorprofiledal.GetAllClinicVendorProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> ClinicProfileDetails_InsertUpdate(ClinicVendorProfileModel item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.ClinicProfileDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<int> ClinicDoctorDetails_InsertUpdate(ClinicDoctorModel item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.ClinicDoctorDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<ClinicDoctorModel>> GetClinicDoctorsDetailsByClinicVendorID(int ClinicVendorID)
        {
            try
            {
                var result = await _clinicvendorprofiledal.GetClinicDoctorsDetailsByClinicVendorID(ClinicVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClinicDoctorSlotModel> SetClinicDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.SetClinicDoctorSlots(ClinicDoctorID, ClinicVendorID, Date, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ClinicSlotDateModel>> GetClinicDoctorSlotsByDateandID([FromBody] int ClinicDoctorID, [FromBody] DateTime Date)
        {
            try
            {
                var result = await _clinicvendorprofiledal.GetClinicDoctorSlotsByDateandID(ClinicDoctorID, Date);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClinicDoctorSlotModel> SetClinicVisitDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.SetClinicVisitDoctorSlots(ClinicDoctorID, ClinicVendorID, Date, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ClinicSlotDateModel>> GetClinicVisitDoctorSlotsByDateandID([FromBody] int ClinicDoctorID, [FromBody] DateTime Date)
        {
            try
            {
                var result = await _clinicvendorprofiledal.GetClinicVisitDoctorSlotsByDateandID(ClinicDoctorID, Date);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> ClinicVendorProfileImageDetails_InsertUpdate(ClinicVendorProfileImageModel item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.ClinicVendorProfileImageDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> ClinicDoctorProfileImageDetails_InsertUpdate(ClinicDoctorProfileImageModel item)
        {
            try
            {
                var result = await _clinicvendorprofiledal.ClinicDoctorProfileImageDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}


            
