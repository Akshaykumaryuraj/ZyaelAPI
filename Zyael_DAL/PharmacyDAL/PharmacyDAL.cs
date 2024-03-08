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
using Zyael_Models.PharmacyModel;

namespace Zyael_DAL.PharmacyDAL
{
    public class PharmacyDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public PharmacyDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<PharmacyModel> PharmacyVendorCredentialAdd(int PharmacyVendorID)
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
                                PharmacyVendorID = PharmacyVendorID

                            };
                    return (await con.QueryAsync<PharmacyModel>("Sp_GetHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> PharmacyVendorCredentialDetails_InsertUpdate(PharmacyModel item)
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
                                HospitalVendorID = item.PharmacyVendorID,
                                HospitalVendorEmail = item.PharmacyVendorEmail,
                                HospitalVendorPassword = item.PharmacyVendorPassword,
                                HospitalVendorUserName = item.PharmacyVendorUserName,
                                status = item.status,
                                FirstName = item.PharmacyVendorFirstName,
                                LastName = item.PharmacyVendorLastName





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

        public async Task<PharmacyModel> PharmacyVendorCredentialDetailsDelete(int PharmacyVendorID)
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
                                PharmacyVendorID = PharmacyVendorID

                            };
                    var response = await con.ExecuteScalarAsync<PharmacyModel>("SP_getHospitalDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PharmacyModel>> GetAllPharmacyVendorCredentialDetails()
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
                    return (await con.QueryAsync<PharmacyModel>("Sp_GetAllHospitalCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
