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
using Zyael_Models.Clinics;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Users;

namespace Zyael_DAL.InternalDoctor
{
     public class InternalDoctorDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public InternalDoctorDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }



        public async Task<int> InternalDoctorDetails_InsertUpdate(InternalDoctorModel item)
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
                                IDoctorID = item.IDoctorID,
                                EmailAddress = item.EmailAddress,
                                UserName = item.UserName,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Gender = item.Gender,
                                Phone = item.Phone,
                                ConsultationCategory = item.ConsultationCategory,
                                ConsultationFees = item.ConsultationFees,
                                Specialization = item.Specialization,
                                status = item.status,
                                HospitalVendorID = item.HospitalVendorID,
                                Studies = item.Studies,
                                Experience = item.Experience,
                                City = item.City,
                                ProficientLanguage = item.ProficientLanguage,
                                DoctorBio = item.DoctorBio,
                                DoctorBio_1 = item.DoctorBio_1,
                                DoctorBio_2 = item.DoctorBio_2,
                                DoctorIntroVideoLink = item.DoctorIntroVideoLink,
                                DoctorProcedure = item.DoctorProcedure,
                                DoctorProcedure_1 = item.DoctorProcedure_1,
                                DoctorProcedure_2 = item.DoctorProcedure_2



                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetInternalDoctorDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<List<InternalDoctorModel>> GetInternalDoctorsDetailsByHospitalVendorID(int HospitalVendorID)
        
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
                    return (await con.QueryAsync<InternalDoctorModel>("SP_getInternalDoctorDetailsByHospitalVendorID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<ShiftSlotModel> SetInternalDoctorSlots(int IDoctorID,int HospitalVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            ShiftSlotModel result = new ShiftSlotModel();
            //IEnumerable<string> count = SlotsAvailable.Select(count = > count.ToString());

            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var del =
                           new
                           {
                               IDoctorID = IDoctorID,
                               Date = Date

                           };
                    var response = await con.ExecuteScalarAsync<ShiftSlotModel>("SP_InternalDoctorSlotDetailsDelete", del, commandType: System.Data.CommandType.StoredProcedure);
                    foreach (var item1 in item)
                    {


                        var Param =
                                new
                                {
                                    IDoctorID = IDoctorID,
                                    HospitalVendorID= HospitalVendorID,
                                    Date = Date,
                                    Time = item1.Time,
                                    Available = item1.Available


                                };
                        await con.ExecuteScalarAsync<ShiftSlotModel>("SP_SetInternalDoctorSlots", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.Shits = item.ToList();
                    result.IDoctorID = IDoctorID;
                    result.HospitalVendorID = HospitalVendorID;
                    result.Date = Date;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ShiftSlotModel>> GetInternalDoctorAvailableSlots(int IDoctorID)
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
                                IDoctorID = IDoctorID

                            };
                    return (await con.QueryAsync<ShiftSlotModel>("Sp_GetAvailableSlotDetailsByInternalDoctorId", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ShiftSlotDateModel>> GetInternalDoctorSlotsByDateandID(int IDoctorID, DateTime Date)
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
                                IDoctorID = IDoctorID,
                                Date = Date

                            };
                    return (await con.QueryAsync<ShiftSlotDateModel>("SP_GetInternalDoctorSlotsByDate", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> InternalDoctorProfileImageDetails_InsertUpdate(InternalDoctorProfileImageModel item)
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

                                IDoctorProfileImageID = item.IDoctorProfileImageID,
                                HospitalVendorID = item.HospitalVendorID,
                                IDoctorID = item.IDoctorID,
                                IDoctorProfileImageName = item.IDoctorProfileImageName,
                                IDoctorProfileImagePath = item.IDoctorProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetInternalDoctorProfileImageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
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
