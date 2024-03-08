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

namespace Zyael_DAL.Hospital
{
    public class HospitalDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public HospitalDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<HospitalModel> HospitalCredentialAdd(int HospitalVendorID)
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
                            HospitalVendorID = HospitalVendorID

                        };
                    return (await con.QueryAsync<HospitalModel>("Sp_GetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> HospitalCredentialDetails_InsertUpdate(HospitalModel item)
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
                                HospitalVendorID = item.HospitalVendorID,
                            HospitalVendorEmail = item.HospitalVendorEmail,
                            HospitalVendorPassword = item.HospitalVendorPassword,
                            HospitalVendorUserName = item.HospitalVendorUserName,
                            status = item.status,
                            FirstName = item.FirstName,
                            LastName  = item.LastName





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

        public async Task<HospitalModel> HospitalCredentialDetailsDelete(int HospitalVendorID)
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
                                HospitalVendorID = HospitalVendorID

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


        public async Task<List<HospitalModel>> GetAllHospitalCredentialDetails()
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
                    return (await con.QueryAsync<HospitalModel>("Sp_GetAllHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
