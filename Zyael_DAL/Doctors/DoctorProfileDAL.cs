using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Doctors;
using Zyael_Models.Notifications;
using Zyael_Models.Pharmacy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zyael_DAL.Doctors
{

    public class DoctorProfileDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public DoctorProfileDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<List<DoctorProfileModel>> GetAllDoctorsProfileDetails()
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
                    return (await con.QueryAsync<DoctorProfileModel>("Sp_GetAllDoctorsProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DoctorProfileModel> GetDoctorsProfileDetails(int DoctorPId)
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
                                DoctorPId = DoctorPId

                            };
                    return (await con.QueryAsync<DoctorProfileModel>("Sp_GetDoctorsProfileDetailsbyId", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public async Task<int> SetDoctorSlots(ConsultationSlotModel DoctorID, [FromBody] List<ScheduleSlots> item)

        //public async Task<int> SetDoctorSlots(ConsultationSlotModel item)
        //{

        //    try
        //    {

        //        using (SqlConnection con = GetConnection())
        //        {
        //            con.Open();
        //            var Param =
        //                new
        //                {
        //                    Available =Available,
        //                    Time = Time,
        //                    DoctorID =DoctorID
        //                };
        //            var response = await con.Execut1111111111111111111111111111111111111111111111111111111111111111111111111111111`1seScalarAsync<int>("SP_SetDoctorSlots", Param, commandType: System.Data.CommandType.StoredProcedure);
        //            return response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}

        public async Task<ConsultationSlotModel> SetDoctorSlots(int DoctorID, DateTime Date, [FromBody] List<slots> item)
        {
            ConsultationSlotModel result = new ConsultationSlotModel();
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
                               DoctorID = DoctorID,
                               Date = Date

                           };
                    var response = await con.ExecuteScalarAsync<ConsultationSlotModel>("SP_DoctorSlotDetailsDelete", del, commandType: System.Data.CommandType.StoredProcedure);
                    foreach (var item1 in item)
                    {


                        var Param =
                                new
                                {
                                    DoctorID = DoctorID,

                                    Date = Date,
                                    Time = item1.Time,
                                    Available = item1.Available


                                };
                        await con.ExecuteScalarAsync<ConsultationSlotModel>("SP_SetDoctorSlots", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.slots = item.ToList();
                    result.DoctorID = DoctorID;
                    result.Date = Date;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ConsultationSlotModel>> GetAvailableSlots(int DoctorID)
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
                                DoctorID = DoctorID

                            };
                    return (await con.QueryAsync<ConsultationSlotModel>("Sp_GetAvailableSlotDetailsByDoctorId", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public async Task<ConsultationSlotModel> GetDoctorSlotsByDate(int DoctorID, DateTime Date)
        //{
        //    ConsultationSlotModel result = new ConsultationSlotModel();

        //    try
        //    {

        //        var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
        //        using (SqlConnection con = Connection)
        //            {
        //               con.Open();

        //            {
        //                var Param =
        //                        new
        //                        {
        //                            DoctorID = DoctorID,
        //                            Date = Date
        //                            //Time = item1.Time,
        //                            //Available = item1.Available


        //                        };
        //                await con.ExecuteScalarAsync<ConsultationSlotModel>("SP_GetDoctorSlotsByDate", Param, commandType: System.Data.CommandType.StoredProcedure.ToList()); ;

        //            }

        //            //result.DoctorID = DoctorID;
        //            //result.Date = Date;
        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}




        public async Task<List<ConsultationSlotDateModel>> GetDoctorSlotsByDateandID(int DoctorID, DateTime Date)
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
                                DoctorID = DoctorID,
                                Date = Date

                            };
                    return (await con.QueryAsync<ConsultationSlotDateModel>("SP_GetDoctorSlotsByDate", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DoctorProfileDetails_InsertUpdate(DoctorProfileModel item, List<achievements> achievements)
        {
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
                                    DoctorPId = item.DoctorPId,
                                    DoctorID = item.DoctorID,
                                    FirstName = item.FirstName,
                                    LastName = item.LastName,
                                    Gender = item.Gender,
                                    Studies = item.Studies,
                                    Experience = item.Experience,
                                    Phone = item.Phone,
                                    ConsultationCategory = item.ConsultationCategory,
                                    ConsultationFees = item.ConsultationFees,
                                    City = item.City,
                                    ProficientLanguage = item.ProficientLanguage,
                                    Specialization = item.Specialization,
                                    status = item.status,
                                    DoctorBio = item.DoctorBio,
                                    DoctorBio_1 = item.DoctorBio_1,
                                    DoctorBio_2 = item.DoctorBio_2,
                                    DoctorIntroVideoLink = item.DoctorIntroVideoLink,
                                    DoctorProcedure = item.DoctorProcedure,
                                    DoctorProcedure_1 = item.DoctorProcedure_1,
                                    DoctorProcedure_2 = item.DoctorProcedure_2
                                    //DoctorProfileImageName = item.DoctorProfileImageName,
                                    //DoctorProfileImagePath = item.DoctorProfileImagePath
                                    //DoctorProfileImageName = img.DoctorProfileImageName,
                                    //DoctorProfileImagePath = img.DoctorProfileImagePath


                                };
                        var response = await con.ExecuteScalarAsync<int>("Sp_SetDoctorProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                        foreach (var item1 in achievements)
                        {


                            var test =
                                    new
                                    {
                                        DoctorPId=item.DoctorPId,
                                        DoctorID = item.DoctorID,
                                        Title=item1.Title,
                                        Description=item1.Description

                                    };
                            await con.ExecuteScalarAsync<achievements>("SP_SetDoctorAchievementsDetails", test, commandType: System.Data.CommandType.StoredProcedure);

                        }
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

        }

        public async Task<List<achievements>> GetDoctorAchievementsDetailsByID(int DoctorID)
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
                                DoctorID = DoctorID

                            };
                    return (await con.QueryAsync<achievements>("SP_GetDoctorAchievementsDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                     

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> DoctorProfileImageDetails_InsertUpdate(DoctorProfileImageModel item)
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

                                DoctorProfileImageID = item.DoctorProfileImageID,
                                DoctorID = item.DoctorID,
                                DoctorPId = item.DoctorPId,
                                DoctorProfileImageName = item.DoctorProfileImageName,
                                DoctorProfileImagePath = item.DoctorProfileImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetDoctorProfileImageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
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

