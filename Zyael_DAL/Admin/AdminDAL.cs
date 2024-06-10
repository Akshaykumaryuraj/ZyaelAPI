using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Admins;
using Zyael_Models.Hospitals;
using Zyael_Models.InternalDoctor;

namespace Zyael_DAL.Admin
{
    public class AdminDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public AdminDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<int> ZyaelPromiseDetails_InsertUpdate(Zyael_PromiseModel item)
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
                                ZyaelPID = item.ZyaelPID,
                                Title = item.Title,
                                CheckList_1 = item.CheckList_1,
                                CheckList_2 = item.CheckList_2,
                                CheckList_3 = item.CheckList_3,
                                CheckList_4 = item.CheckList_4,
                                desc_1 = item.desc_1,
                                desc_2 = item.desc_2


                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetZyaelPromiseDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<Zyael_PromiseModel> GetZyaelPromiseDetails(int ZyaelPID)
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
                                ZyaelPID = ZyaelPID

                            };
                    return (await con.QueryAsync<Zyael_PromiseModel>("Sp_GetZyaelPromiseDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
