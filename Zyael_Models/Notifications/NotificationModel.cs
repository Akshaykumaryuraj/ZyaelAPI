using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Notifications
{
    public class NotificationModel
    {
        public int NotificationID { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationDescription { get; set; }
        public IFormFile NotificationImage { get; set; }

        public string NotificationImageName { get; set; }
        public string NotificationImagePath { get; set; }
    }
}
