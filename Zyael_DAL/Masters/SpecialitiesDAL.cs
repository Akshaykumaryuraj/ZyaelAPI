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
using Zyael_Models.Masters;
using Zyael_Models.Users;

namespace Zyael_DAL.Masters
{
    public class SpecialitiesDAl : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public SpecialitiesDAl(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }
        public async Task<SpecialitiesModel> SpecialitiesDetailsAdd(int SpecialityID)
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
                                SpecialityID = SpecialityID

                            };
                    return (await con.QueryAsync<SpecialitiesModel>("Sp_GetMastersSpecialitiesDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> SpecialitiesDetails_InsertUpdate(SpecialitiesModel item)
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
                                SpecialityID = item.SpecialityID,
                                SpecialityName = item.SpecialityName,
                                SpecialityCode = item.SpecialityCode,
                                Symptoms = item.Symptoms

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetMastersSpecialitiesDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<List<SpecialitiesModel>> GetAllSpecialitiesDetails()
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
                    return (await con.QueryAsync<SpecialitiesModel>("Sp_GetAllMastersSpecialitiesDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
    
