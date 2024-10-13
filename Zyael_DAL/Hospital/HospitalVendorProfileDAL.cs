﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Doctors;
using Zyael_Models.Hospitals;
using Zyael_Models.Users;

namespace Zyael_DAL.HospitalUserProfile
{
    public class HospitalVendorProfileDAL:SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public HospitalVendorProfileDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<List<HospitalVendorProfileModel>> GetAllHospitalVendorProfileDetails()
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
                    return (await con.QueryAsync<HospitalVendorProfileModel>("Sp_GetAllHospitalPofileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> HospitalProfileDetails_InsertUpdate(HospitalVendorProfileModel item)
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
                                HospitalProfileID = item.HospitalProfileID,
                                HospitalVendorID = item.HospitalVendorID,
                                HospitalVendorUserName = item.HospitalVendorUserName,
                                HospitalVendorEmail = item.HospitalVendorEmail,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Location = item.Location,              
                                ContactNumber = item.ContactNumber,
                                EmergencyContact = item.EmergencyContact,
                                Rating = item.Rating,
                                Specialization=item.Specialization
                                //HospitalProfileImageName=item.HospitalProfileImageName,
                                //HospitalProfileImagePath=item.HospitalProfileImagePath






                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetHospitalProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<int> HospitalVendorProfileImageDetails_InsertUpdate(HospitalVendorProfileImageModel item)
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

                                HospitalProfileImageID = item.HospitalProfileImageID,
                                HospitalVendorID = item.HospitalVendorID,
                                HospitalProfileID = item.HospitalProfileID,
                                HospitalProfileImageName = item.HospitalProfileImageName,
                                HospitalProfileImagePath = item.HospitalProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetHospitalVendorProfileImageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
