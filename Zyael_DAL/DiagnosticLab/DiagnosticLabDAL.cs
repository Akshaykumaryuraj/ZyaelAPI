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
using Zyael_Models.Hospitals;

namespace Zyael_DAL.DiagnosticLab
{
    public class DiagnosticDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public DiagnosticDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<DiagnosticLabModel> DiagnosticLabCredentialAdd(int DiagnosticLabVendorID)
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
                                DiagnosticLabVendorID = DiagnosticLabVendorID

                            };
                    return (await con.QueryAsync<DiagnosticLabModel>("Sp_GetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> DiagnosticLabCredentialDetails_InsertUpdate(DiagnosticLabModel item)
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
                                DiagnosticLabVendorID = item.DiagnosticLabVendorID,
                                DiagnosticLabVendorEmail = item.DiagnosticLabVendorEmail,
                                DiagnosticLabVendorPassword = item.DiagnosticLabVendorPassword,
                                DiagnosticLabVendorUserName = item.DiagnosticLabVendorUserName,
                                status = item.status,

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<HospitalModel> DiagnosticLabCredentialDetailsDelete(int DiagnosticLabVendorID)
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
                                DiagnosticLabVendorID = DiagnosticLabVendorID

                            };
                    var response = await con.ExecuteScalarAsync<HospitalModel>("SP_getHospitalDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
