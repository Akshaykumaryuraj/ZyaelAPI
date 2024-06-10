using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Hospitals;
using Zyael_Models.Logins;

namespace Zyael_DAL.Logins
{
    public class UserLoginDAl : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public UserLoginDAl(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }
        public async Task<UserLoginModel> UserLoginCredentialAdd(int UserID)
        {
            try
            {
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                UserID = UserID

                            };
                    return (await con.QueryAsync<UserLoginModel>("Sp_GetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                UserID = item.UserID,
                                //FirstName = item.FirstName,
                                //Email = item.Email,
                                PhoneNumber = item.PhoneNumber,
                                UID = item.UID
                                //Password = item.Password



                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetUserRegistrationDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<UserLoginModel> SetUserLogin(UserLoginModel item)
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

                            PhoneNumber = item.PhoneNumber,
                            UID = item.UID

                        };
                    return (await con.QueryAsync<UserLoginModel>("sp_checkUserLogin", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
