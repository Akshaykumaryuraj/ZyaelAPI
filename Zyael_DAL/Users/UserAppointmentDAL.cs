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
using Zyael_Models.Doctors;
using Zyael_Models.Logins;
using Zyael_Models.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zyael_DAL.Users
{
    public class UserAppointmentDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public UserAppointmentDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<UserAppointmentScheduleModel> SetUserAppointment([FromBody]UserAppointmentScheduleModel app_dels,int UserRandomID)
        {
            UserAppointmentScheduleModel result = new UserAppointmentScheduleModel();
            //IEnumerable<string> count = SlotsAvailable.Select(count = > count.ToString());
            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                                       {

                        var Param =
                                new
                                {
                                    UserID= app_dels.UserID,
                                    DoctorID = app_dels.DoctorID,
                                    Date = app_dels.Date,
                                    UserSelectedSlot =app_dels.UserSelectedSlot,
                                    PaymentID= app_dels.PaymentID,
                                    PaymentOrderID= app_dels.PaymentOrderID,
                                    UserRandomID =UserRandomID,
                                    ConsultationFees= app_dels.ConsultationFees,
                                    AppointmentUpdate=app_dels.AppointmentUpdate


                                };
                        await con.ExecuteScalarAsync<UserAppointmentScheduleModel>("SP_SetUserAppointmentScheduleDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.DoctorID = app_dels.DoctorID;
                    result.Date = app_dels.Date;
                    result.UserID= app_dels.UserID;
                    result.UserRandomID = UserRandomID;
                    result.AppointmentUpdate = app_dels.AppointmentUpdate;
                    result.UserSelectedSlot = app_dels.UserSelectedSlot;
                    result.ConsultationFees = app_dels.ConsultationFees;
                    result.PaymentOrderID = app_dels.PaymentOrderID;
                    result.PaymentID = app_dels.PaymentID;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<UserAppointmentScheduleModel> UploadHtmlFile(IFormFile file)
        {
            UserAppointmentScheduleModel result = new UserAppointmentScheduleModel();
            //IEnumerable<string> count = SlotsAvailable.Select(count = > count.ToString());

            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    {

                        var Param =
                                new
                                {
                                    file=file

                                };
                        await con.ExecuteScalarAsync<UserAppointmentScheduleModel>("SP_SetUserAppointmentScheduleDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                  
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<UserAppointmentScheduleModel>> GetUserAppointmentByUserID(int UserID)
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
                                UserID = UserID


                            };
                    return (await con.QueryAsync<UserAppointmentScheduleModel>("Sp_GetUserAppointmentByUserID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<UserHospitalAppointmentModel> SetUserHospitalAppointment([FromBody] UserHospitalAppointmentModel app_dels, int UserRandomID)
        {
            UserHospitalAppointmentModel result = new UserHospitalAppointmentModel();
            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    {

                        var Param =
                                new
                                {
                                    UserID = app_dels.UserID,
                                    IDoctorID = app_dels.IDoctorID,
                                    HospitalVendorID=app_dels.HospitalVendorID,
                                    Date = app_dels.Date,
                                    UserSelectedSlot = app_dels.UserSelectedSlot,
                                    PaymentID = app_dels.PaymentID,
                                    PaymentOrderID = app_dels.PaymentOrderID,
                                    UserRandomID = UserRandomID,
                                    ConsultationFees = app_dels.ConsultationFees,
                                    AppointmentUpdate = app_dels.AppointmentUpdate


                                };
                        await con.ExecuteScalarAsync<UserHospitalAppointmentModel>("SP_SetUserHospitalAppointmentScheduleDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.IDoctorID = app_dels.IDoctorID;
                    result.HospitalVendorID = app_dels.HospitalVendorID;
                    result.Date = app_dels.Date;
                    result.UserID = app_dels.UserID;
                    result.UserRandomID = UserRandomID;
                    result.AppointmentUpdate = app_dels.AppointmentUpdate;
                    result.UserSelectedSlot = app_dels.UserSelectedSlot;
                    result.ConsultationFees = app_dels.ConsultationFees;
                    result.PaymentOrderID = app_dels.PaymentOrderID;
                    result.PaymentID = app_dels.PaymentID;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<UserHospitalAppointmentModel>> GetUserHospitalAppointmentByUserID(int UserID)
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
                                UserID = UserID


                            };
                    return (await con.QueryAsync<UserHospitalAppointmentModel>("Sp_GetUserHospitalAppointmentByUserID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public async Task<UserClinicAppointmentModel> SetUserClinicAppointment([FromBody] UserClinicAppointmentModel app_dels, int UserRandomID)
        {
            UserClinicAppointmentModel result = new UserClinicAppointmentModel();
            try
            {

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    {

                        var Param =
                                new
                                {
                                    UserID = app_dels.UserID,
                                    ClinicDoctorID = app_dels.ClinicDoctorID,
                                    ClinicVendorID = app_dels.ClinicVendorID,
                                    Date = app_dels.Date,
                                    UserSelectedSlot = app_dels.UserSelectedSlot,
                                    PaymentID = app_dels.PaymentID,
                                    PaymentOrderID = app_dels.PaymentOrderID,
                                    UserRandomID = UserRandomID,
                                    ConsultationFees = app_dels.ConsultationFees,
                                    ConsultationType = app_dels.ConsultationType,
                                    AppointmentUpdate = app_dels.AppointmentUpdate


                                };
                        await con.ExecuteScalarAsync<UserClinicAppointmentModel>("SP_SetUserClinicAppointmentScheduleDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                    }

                    result.ClinicDoctorID = app_dels.ClinicDoctorID;
                    result.ClinicVendorID = app_dels.ClinicVendorID;
                    result.Date = app_dels.Date;
                    result.UserID = app_dels.UserID;
                    result.UserRandomID = UserRandomID;
                    result.AppointmentUpdate = app_dels.AppointmentUpdate;
                    result.UserSelectedSlot = app_dels.UserSelectedSlot;
                    result.ConsultationFees = app_dels.ConsultationFees;
                    result.PaymentOrderID = app_dels.PaymentOrderID;
                    result.PaymentID = app_dels.PaymentID;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<UserClinicAppointmentModel>> GetUserClinicAppointmentByUserID(int UserID)
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
                                UserID = UserID


                            };
                    return (await con.QueryAsync<UserClinicAppointmentModel>("Sp_GetUserClinicAppointmentByUserID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<int> UserCancelAppointmentDetails_InsertUpdate(UserCancelAppointmentModel item)
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
                                UserID = item.UserID,
                                DoctorID = item.DoctorID,
                                UAID = item.UAID,
                                Comment = item.Comment



                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetUserAppointmentCancelDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
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
