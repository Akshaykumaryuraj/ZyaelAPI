using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Clinics
{
        public class ClinicModel
        {
            public int ClinicVendorID { get; set; }
            public string ClinicVendorEmail { get; set; }
            public string ClinicVendorPassword { get; set; }
            public string ClinicVendorUserName { get; set; }
            public string message { get; set; }

            public int returnId { get; set; }

            public bool status { get; set; }

        }
    }

