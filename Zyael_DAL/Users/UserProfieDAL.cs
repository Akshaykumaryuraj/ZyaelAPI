using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Logins;
using Zyael_Models.Users;

namespace Zyael_DAL.Users
{
    public class UserProfieDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public UserProfieDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<UserProfileModel> UserLoginCredentialAdd(int UserPID)
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
                                UserPID = UserPID

                            };
                    return (await con.QueryAsync<UserProfileModel>("Sp_GetUserProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> UserProfileDetails_InsertUpdate(UserProfileModel item)
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
                                UserPID = item.UserPID,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Gender = item.Gender,
                                DOB = item.DOB,
                                BloodGroup = item.BloodGroup,
                                MaritalStatus = item.MaritalStatus,
                                Height = item.Height,
                                Weight = item.Weight,
                                EmergencyContact = item.EmergencyContact,
                                Location = item.Location,
                                EmergencyContactRelation = item.EmergencyContactRelation,
                                Allergies = item.Allergies,
                                CurrentMedications = item.CurrentMedications,
                                PastMedications = item.PastMedications,
                                Injuries = item.Injuries,
                                Surgeries = item.Surgeries,
                                Smoking = item.Smoking,
                                Alcohol = item.Alcohol,
                                FoodPreference = item.FoodPreference,
                                Occupation = item.Occupation





                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetUserProfileDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
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
