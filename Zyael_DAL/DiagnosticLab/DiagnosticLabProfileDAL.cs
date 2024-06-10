using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.DiagnosticLabs;

namespace Zyael_DAL.DiagnosticLab
{
    public class DiagnosticProfileDAL:SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public DiagnosticProfileDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<List<DiagnosticLabModel>> GetAllDiagnosticProfileDetails()
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
                    return (await con.QueryAsync<DiagnosticLabModel>("Sp_GetAllDiagnosticLabProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<DiagnosticLabModel> DiagnosticLabProfileDetailsByID(int DLVPID)
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
                                DLVPID = DLVPID

                            };
                    return (await con.QueryAsync<DiagnosticLabModel>("Sp_GetDiagnosticVendorProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
