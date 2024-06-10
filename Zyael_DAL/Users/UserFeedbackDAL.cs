using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Doctors;
using Zyael_Models.Users;

namespace Zyael_DAL.Users
{
    public class UserFeedbackDAl : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public UserFeedbackDAl(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<int> UserFeedbackDetails_InsertUpdate(UserFeedbackModel item)
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
                                UserFeedbackID=item.UserFeedbackID,
                                DoctorID = item.DoctorID,
                                UserID=item.UserID,
                                Comment = item.Comment,
                                Rating = item.Rating

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetUserFeedbackDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {

                            };
                    return (await con.QueryAsync<UserFeedbackModel>("Sp_GetAllUserFeedbackDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
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

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                DoctorID = DoctorID

                            };
                    return (await con.QueryAsync<UserFeedbackModel>("Sp_GetUserFeedbackByDoctorID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}

