﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL;
using Zyael_Models;
namespace Zyael_Services
{
    public class Login
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public LoginDAL _logindal;
        public Login(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _logindal = new LoginDAL(httpContextAccessor,config);
        }


        public async Task<LoginModel> SetAdminLogin(LoginModel item)
        {
            try
            {
                var result = await _logindal.SetAdminLogin(item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
