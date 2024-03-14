using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL;
using Zyael_DAL.Hospital;
using Zyael_DAL.Logins;
using Zyael_Models.Hospitals;
using Zyael_Models.Logins;


namespace Zyael_Services.Con_Services
{
    public class UserLogin
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserLoginDAl _userlogindal;
        public UserLogin(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _userlogindal = new UserLoginDAl(httpContextAccessor, config);
        }



        public async Task<UserLoginModel> UserLoginCredentialAdd(int UserID)
        {
            try
            {
                var result = await _userlogindal.UserLoginCredentialAdd(UserID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> UserCredentialDetails_InsertUpdate(UserLoginModel item)
        {
            try
            {
                var result = await _userlogindal.UserCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<UserLoginModel> SetUserLogin(UserLoginModel item)
        {
            try
            {
                var result = await _userlogindal.SetUserLogin(item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

