using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.PharmacyModel
{
    public  class PharmacyModel
    {

       public int PharmacyVendorID { get; set; }
        public string PharmacyVendorEmail { get; set; }
        public string PharmacyVendorPassword { get; set; }
        public string PharmacyVendorUserName { get; set; }
        public string PharmacyVendorFirstName { get; set; }
        public string PharmacyVendorLastName { get; set; }
        public string message { get; set; }

        public int returnId { get; set; }

        public bool status { get; set; }

    }
}
