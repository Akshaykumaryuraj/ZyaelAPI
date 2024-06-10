using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Doctors;
using Zyael_Models.Masters;

namespace Zyael_DAL.Masters
{
   public class SymptomsDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public SymptomsDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<SymptomsModel> SetSymptoms(string SymptomTitle, [FromBody] List<symptomslist> item)
        {
            SymptomsModel result = new SymptomsModel();

            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                   
                    foreach (var item1 in item)
                    {


                        var Param =
                                new
                                {
                                    SymptomList = item1.SymptomList,
                                    SymptomTitle= SymptomTitle,
                                    Priority = item1.Priority,


                                };
                        await con.ExecuteScalarAsync<SymptomsModel>("SP_SetSymptomsDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.symptomslist = item.ToList();
                  
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<symptomslist>> GetSymptoms()
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
                    return (await con.QueryAsync<symptomslist>("Sp_GetSymptomsDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<symptomslist>> GetSymptoms(string SymptomTitle)
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
                                SymptomTitle = SymptomTitle

                            };
                    return (await con.QueryAsync<symptomslist>("Sp_GetSymptomsDetailsByTitle", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
