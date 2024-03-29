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

namespace Zyael_DAL.Doctors
{
   
        public class DoctorProfileDAL : SqlDAL
        {
            readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IConfiguration _config;
            public DoctorProfileDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
            {
                this._httpContextAccessor = httpContextAccessor;
                _config = config;
            }


        public async Task<List<DoctorRegistrationModel>> GetAllDoctorsProfileDetails()
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
                    return (await con.QueryAsync<DoctorRegistrationModel>("Sp_GetAllDoctorsProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DoctorProfileModel> GetDoctorsProfileDetails(int DoctorPId)
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
                                DoctorPId = DoctorPId

                            };
                    return (await con.QueryAsync<DoctorProfileModel>("Sp_GetDoctorsProfileDetailsbyId", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
