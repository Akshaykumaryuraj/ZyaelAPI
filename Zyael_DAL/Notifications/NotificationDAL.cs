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
using Zyael_Models.Notifications;

namespace Zyael_DAL.Notifications
{
   public class NotificationDAL : SqlDAL
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public NotificationDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<int> NotificationDetails_InsertUpdate(NotificationModel item)
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

                                NotificationID = item.NotificationID,
                                NotificationTitle = item.NotificationTitle,
                                NotificationType = item.NotificationType,
                                NotificationDescription = item.NotificationDescription,
                                NotificationImageName = item.NotificationImageName,
                                NotificationImagePath = item.NotificationImagePath

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetNotificationsDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<List<NotificationModel>> GetAllNotificationsDetails()
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
                    return (await con.QueryAsync<NotificationModel>("Sp_GetAllNotificationDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
