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


        public async Task<PharmacyModel> PharmacyVendorCredentialAdd(int PVID)
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
                                PVID = PVID

                            };
                    return (await con.QueryAsync<PharmacyModel>("Sp_GetPharmacyVendorCredentialDetailsById", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
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
                                PVID = item.PVID,
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
                                status = item.status





                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetPharmacyVendorCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<PharmacyModel> PharmacyVendorCredentialDetailsDelete(int PVID)
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
                                PVID = PVID

                            };
                    var response = await con.ExecuteScalarAsync<PharmacyModel>("SP_getPharmacyVendorCredentialDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
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
                    return (await con.QueryAsync<PharmacyModel>("Sp_GetAllPharmacyVendorCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
