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
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;

namespace Zyael_DAL.Clinic
{
        public class ClinicVendorProfileDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public ClinicVendorProfileDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<List<ClinicVendorProfileModel>> GetAllClinicVendorProfileDetails()
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
                    return (await con.QueryAsync<ClinicVendorProfileModel>("Sp_GetAllClinicPofileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> ClinicProfileDetails_InsertUpdate(ClinicVendorProfileModel item)
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
                                ClinicProfileID = item.ClinicProfileID,
                                ClinicVendorID = item.ClinicVendorID,
                                ClinicVendorUserName = item.ClinicVendorUserName,
                                ClinicVendorEmail = item.ClinicVendorEmail,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Location = item.Location,
                                ContactNumber = item.ContactNumber,
                                EmergencyContact = item.EmergencyContact,
                                Rating = item.Rating,
                                Specialization = item.Specialization
                                //ClinicProfileImageName=item.HospitalProfileImageName,
                                //ClinicProfileImagePath=item.HospitalProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetClinicProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> ClinicDoctorDetails_InsertUpdate(ClinicDoctorModel item)
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
                                ClinicDoctorID = item.ClinicDoctorID,
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
                                ClinicVendorID = item.ClinicVendorID,
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
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetClinicDoctorDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<List<ClinicDoctorModel>> GetClinicDoctorsDetailsByClinicVendorID(int ClinicVendorID)

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
                    return (await con.QueryAsync<ClinicDoctorModel>("SP_getClinicDoctorDetailsByClinicVendorID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClinicDoctorSlotModel> SetClinicDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            ClinicDoctorSlotModel result = new ClinicDoctorSlotModel();
            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var del =
                           new
                           {
                               ClinicDoctorID = ClinicDoctorID,
                               Date = Date

                           };
                    var response = await con.ExecuteScalarAsync<ClinicDoctorSlotModel>("SP_ClinicalDoctorSlotDetailsDelete", del, commandType: System.Data.CommandType.StoredProcedure);
                    foreach (var item1 in item)
                    {


                        var Param =
                                new
                                {
                                    ClinicDoctorID = ClinicDoctorID,
                                    ClinicVendorID = ClinicVendorID,
                                    Date = Date,
                                    Time = item1.Time,
                                    Available = item1.Available


                                };
                        await con.ExecuteScalarAsync<ClinicDoctorSlotModel>("SP_SetClinicalDoctorSlots", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.Shits = item.ToList();
                    result.ClinicDoctorID = ClinicDoctorID;
                    result.ClinicVendorID = ClinicVendorID;
                    result.Date = Date;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ClinicSlotDateModel>> GetClinicDoctorSlotsByDateandID(int ClinicDoctorID, DateTime Date)
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
                                ClinicDoctorID = ClinicDoctorID,
                                Date = Date

                            };
                    return (await con.QueryAsync<ClinicSlotDateModel>("SP_GetClinicalDoctorSlotsByDate", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClinicDoctorSlotModel> SetClinicVisitDoctorSlots(int ClinicDoctorID, int ClinicVendorID, DateTime Date, [FromBody] List<Shits> item)
        {
            ClinicDoctorSlotModel result = new ClinicDoctorSlotModel();
            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var del =
                           new
                           {
                               ClinicDoctorID = ClinicDoctorID,
                               Date = Date

                           };
                    var response = await con.ExecuteScalarAsync<ClinicDoctorSlotModel>("SP_ClinicalDoctorSlotDetailsDelete", del, commandType: System.Data.CommandType.StoredProcedure);
                    foreach (var item1 in item)
                    {


                        var Param =
                                new
                                {
                                    ClinicDoctorID = ClinicDoctorID,
                                    ClinicVendorID = ClinicVendorID,
                                    Date = Date,
                                    Time = item1.Time,
                                    Available = item1.Available


                                };
                        await con.ExecuteScalarAsync<ClinicDoctorSlotModel>("SP_SetClinicalVisitDoctorSlots", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.Shits = item.ToList();
                    result.ClinicDoctorID = ClinicDoctorID;
                    result.ClinicVendorID = ClinicVendorID;
                    result.Date = Date;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ClinicSlotDateModel>> GetClinicVisitDoctorSlotsByDateandID(int ClinicDoctorID, DateTime Date)
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
                                ClinicDoctorID = ClinicDoctorID,
                                Date = Date

                            };
                    return (await con.QueryAsync<ClinicSlotDateModel>("SP_GetClinicalVisitDoctorSlotsByDate", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> ClinicVendorProfileImageDetails_InsertUpdate(ClinicVendorProfileImageModel item)
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

                                ClinicProfileImageID = item.ClinicProfileImageID,
                                ClinicVendorID = item.ClinicVendorID,
                                ClinicProfileID = item.ClinicProfileID,
                                ClinicProfileImageName = item.ClinicProfileImageName,
                                ClinicProfileImagePath = item.ClinicProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetClinicVendorProfileImageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }



        public async Task<int> ClinicDoctorProfileImageDetails_InsertUpdate(ClinicDoctorProfileImageModel item)
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

                                ClinicDoctorProfileImageID = item.ClinicDoctorProfileImageID,
                                ClinicVendorID = item.ClinicVendorID,
                                ClinicProfileID = item.ClinicProfileID,
                                ClinicDoctorProfileImageName = item.ClinicDoctorProfileImageName,
                                ClinicDoctorProfileImagePath = item.ClinicDoctorProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetClinicDoctorProfileImageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
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
