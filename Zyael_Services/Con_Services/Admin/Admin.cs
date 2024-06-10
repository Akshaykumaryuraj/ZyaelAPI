using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Admin;
using Zyael_DAL.Hospital;
using Zyael_DAL.InternalDoctor;
using Zyael_Models.Admins;
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;

namespace Zyael_Services.Con_Services.Admin
{
    public class Admin
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public AdminDAL _admindal;
        public Admin(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _admindal = new AdminDAL(httpContextAccessor, config);
        }

        public async Task<int> ZyaelPromiseDetails_InsertUpdate(Zyael_PromiseModel item)
        {
            try
            {
                var result = await _admindal.ZyaelPromiseDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<Zyael_PromiseModel> GetZyaelPromiseDetails(int ZyaelPID)
        {
            try
            {
                var result = await _admindal.GetZyaelPromiseDetails(ZyaelPID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
