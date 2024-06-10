using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Logins;
using Zyael_DAL.Users;
using Zyael_Models.Logins;
using Zyael_Models.Users;

namespace Zyael_Services.Con_Services
{
    public  class UserProfie
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        public UserProfieDAL _userprofiledal;
        public UserProfie(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _userprofiledal = new UserProfieDAL(httpContextAccessor, config);
        }

        public async Task<UserProfileModel> UserProfileDetailsAdd(int UserPID)
        {
            try
            {
                var result = await _userprofiledal.UserLoginCredentialAdd(UserPID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> UserProfileDetails_InsertUpdate(UserProfileModel item)
        {
            try
            {
                var result = await _userprofiledal.UserProfileDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }



        public async Task<int> UserProfile_Upload(UserProfile_Upload item)
        {
            try
            {
                var result = await _userprofiledal.UserProfile_Upload(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
