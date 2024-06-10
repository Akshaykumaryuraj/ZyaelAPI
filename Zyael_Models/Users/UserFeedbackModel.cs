using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Users
{
    public class UserFeedbackModel
    {
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int UserFeedbackID { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
