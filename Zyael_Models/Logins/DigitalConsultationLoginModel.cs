using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Logins
{
    public class DigitalConsultationLoginModel
    {
     
        public int DoctorID { get; set; }
        public String EmailAddress { get; set; }
        public String Password { get; set; }
        public String UserName { get; set; }
        public int returnId { get; set; }

        public bool status { get; set; }
    }
}
