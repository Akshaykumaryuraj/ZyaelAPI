using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.Users;
using Zyael_Models.Doctors;
using Zyael_Models.Users;

namespace Zyael_Services.Con_Services
{
    public class UserFeedback
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserFeedbackDAl _userfeedbackdal;
        public UserFeedback(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _userfeedbackdal = new UserFeedbackDAl(httpContextAccessor, config);
        }

        public async Task<int> UserFeedbackDetails_InsertUpdate(UserFeedbackModel item)
        {
            try
            {
                var result = await _userfeedbackdal.UserFeedbackDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<UserFeedbackModel>> GetAllUserFeedbackDetails()
        {
            try
            {
                var result = await _userfeedbackdal.GetAllUserFeedbackDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<UserFeedbackModel>> GetUserFeedbackByDoctorID(int DoctorID)
        {
            try
            {
                var result = await _userfeedbackdal.GetUserFeedbackByDoctorID(DoctorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        
    }
}
