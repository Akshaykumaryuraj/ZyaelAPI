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

        public async Task<DiagnosticLabModel> DiagnosticLabCredentialAdd(int DLVID)
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
                                DLVID = DLVID

                            };
                    return (await con.QueryAsync<DiagnosticLabModel>("Sp_GetDiagnosticVendorCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
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
                                DLVID = item.DLVID,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Email = item.Email,
                                Password = item.Password,
                                UserName = item.UserName,
                                Gender = item.Gender,
                                Mobile = item.Mobile,
                                Address1 = item.Address1,
                                Address2 = item.Address2,
                                Country = item.Country,
                                State = item.State,
                                City = item.City,
                                status= item.status


                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetDiagnosticVendorCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<HospitalModel> DiagnosticLabCredentialDetailsDelete(int DLVID)
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
                                DLVID = DLVID

                            };
                    var response = await con.ExecuteScalarAsync<HospitalModel>("SP_getDiagnosticVendorCredentialDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<DiagnosticLabModel>> GetAllDiagnosticCredentialDetails()
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
                    return (await con.QueryAsync<DiagnosticLabModel>("Sp_GetAllDiagnosticLabCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
