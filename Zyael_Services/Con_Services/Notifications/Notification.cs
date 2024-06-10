using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.HospitalUserProfile;
using Zyael_DAL.Masters;
using Zyael_DAL.Notifications;
using Zyael_Models.Hospitals;
using Zyael_Models.Notifications;

namespace Zyael_Services.Con_Services.Notifications
{
  public class Notification
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public NotificationDAL _notificationdal;
        public Notification(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _notificationdal = new NotificationDAL(httpContextAccessor, config);
        }

        public async Task<int> NotificationDetails_InsertUpdate(NotificationModel item)
        {
            try
            {
                var result = await _notificationdal.NotificationDetails_InsertUpdate(item);
                return result;
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
                var result = await _notificationdal.GetAllNotificationsDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
