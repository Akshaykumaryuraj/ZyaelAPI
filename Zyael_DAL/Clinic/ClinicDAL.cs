using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Clinics;
using Zyael_Models.Hospitals;

namespace Zyael_DAL.Clinic
{
    public class ClinicDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public ClinicDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<ClinicModel> ClinicCredentialAdd(int ClinicVendorID)
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
                                ClinicVendorID = ClinicVendorID

                            };
                    return (await con.QueryAsync<ClinicModel>("Sp_GetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<int> ClinicCredentialDetails_InsertUpdate(ClinicModel item)
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
                                ClinicVendorID = item.ClinicVendorID,
                                ClinicVendorEmail = item.ClinicVendorEmail,
                                ClinicVendorPassword = item.ClinicVendorPassword,
                                ClinicVendorUserName = item.ClinicVendorUserName,
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

        public async Task<ClinicModel> ClinicCredentialDetailsDelete(int ClinicVendorID)
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
                                ClinicVendorID = ClinicVendorID

                            };
                    var response = await con.ExecuteScalarAsync<ClinicModel>("SP_getHospitalDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
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
