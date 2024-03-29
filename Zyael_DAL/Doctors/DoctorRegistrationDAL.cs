using Dapper;
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

namespace Zyael_DAL.Doctors
{
    public  class DoctorRegistrationDAL:SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public DoctorRegistrationDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<DoctorRegistrationModel> DoctorRegistrationCredentialAdd(int DoctorID)
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
                    return (await con.QueryAsync<DoctorRegistrationModel>("Sp_GetDoctorRegistrationCredentialDetailsbyId", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> DoctorRegistrationCredentialDetails_InsertUpdate(DoctorRegistrationModel item)
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
                                DoctorID = item.DoctorID,
                                EmailAddress = item.EmailAddress,
                                Password = item.Password,
                                UserName = item.UserName,
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
                                status = item.status





                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetDoctorRegistrationCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<DoctorRegistrationModel> DoctorRegistrationCredentialDetailsDelete(int DoctorID)
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
                    var response = await con.ExecuteScalarAsync<DoctorRegistrationModel>("SP_getDoctorRegistrationDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


            public async Task<List<DoctorRegistrationModel>> GetAllDoctorsRegistrationCredentialDetails()
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
                        return (await con.QueryAsync<DoctorRegistrationModel>("Sp_GetAllDoctorRegistrationCredentialDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }


        
    }
}
