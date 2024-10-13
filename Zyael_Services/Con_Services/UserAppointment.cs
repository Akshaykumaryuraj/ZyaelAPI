using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.Logins;
using Zyael_DAL.Users;
using Zyael_Models.Doctors;
using Zyael_Models.Logins;
using Zyael_Models.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zyael_Services.Con_Services
{
    public class UserAppointment
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserAppointmentDAL _userappointmentdal;
        public UserAppointment(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _userappointmentdal = new UserAppointmentDAL(httpContextAccessor, config);
        }

        public async Task<UserAppointmentScheduleModel> SetUserAppointment([FromBody] UserAppointmentScheduleModel app_dels,int UserRandomID)
        {
            try
            {
                var result = await _userappointmentdal.SetUserAppointment(app_dels, UserRandomID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserAppointmentScheduleModel> UploadHtmlFile(IFormFile file)
        {
            try
            {
                var result = await _userappointmentdal.UploadHtmlFile(file);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<UserAppointmentScheduleModel>> GetUserAppointmentByUserID(int UserID)
        {
            try
            {
                var result = await _userappointmentdal.GetUserAppointmentByUserID(UserID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<UserHospitalAppointmentModel> SetUserHospitalAppointment([FromBody] UserHospitalAppointmentModel app_dels, int UserRandomID)
        {
            try
            {
                var result = await _userappointmentdal.SetUserHospitalAppointment(app_dels, UserRandomID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<UserHospitalAppointmentModel>> GetUserHospitalAppointmentByUserID(int UserID)
        {
            try
            {
                var result = await _userappointmentdal.GetUserHospitalAppointmentByUserID(UserID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserClinicAppointmentModel> SetUserClinicAppointment([FromBody] UserClinicAppointmentModel app_dels, int UserRandomID)
        {
            try
            {
                var result = await _userappointmentdal.SetUserClinicAppointment(app_dels, UserRandomID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<UserClinicAppointmentModel>> GetUserClinicAppointmentByUserID(int UserID)
        {
            try
            {
                var result = await _userappointmentdal.GetUserClinicAppointmentByUserID(UserID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> UserCancelAppointmentDetails_InsertUpdate(UserCancelAppointmentModel item)
        {
            try
            {
                var result = await _userappointmentdal.UserCancelAppointmentDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
