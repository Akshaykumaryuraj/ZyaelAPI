using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Logins
{
    public class ClinicConsultationLoginModel
    {
        public int ClinicVendorID { get; set; }
        public int returnId { get; set; }
        public string ClinicVendorUserName { get; set; }

        public string ClinicVendorEmail { get; set; }
        public string ClinicVendorPassword { get; set; }


    }
}
