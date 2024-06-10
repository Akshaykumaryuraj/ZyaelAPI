using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Users;

namespace Zyael_Services.Con_Services
{
     public class UserReports
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserReportsDAL _userreportsdal;
        public UserReports(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _userreportsdal = new UserReportsDAL(httpContextAccessor, config);
        }

   

    }
}
