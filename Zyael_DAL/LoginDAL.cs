using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Logins;
namespace Zyael_DAL
{
    public class LoginDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public LoginDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<LoginModel> SetAdminLogin(LoginModel item)
        {
            //var password = common.PasswordEncription(item.Password);
            try
            {
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                        new
                        {

                            AdminEmail = item.AdminEmail,
                            AdminPassword = item.AdminPassword

                        };
                    return (await con.QueryAsync<LoginModel>("sp_checkAdminLogin", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<HospitalsVendorsLoginModel> SetHositalVendorLogin(HospitalsVendorsLoginModel item)
        {
            //var password = common.PasswordEncription(item.Password);
            try
            {
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                        new
                        {

                            HospitalVendorEmail = item.HospitalVendorEmail,
                            HospitalVendorPassword = item.HospitalVendorPassword,
                            status = item.status

                        };
                    return (await con.QueryAsync<HospitalsVendorsLoginModel>("sp_checkHospitalsVendorLoginDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
