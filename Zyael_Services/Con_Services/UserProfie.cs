using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Logins;
using Zyael_DAL.Users;

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
    }
}
