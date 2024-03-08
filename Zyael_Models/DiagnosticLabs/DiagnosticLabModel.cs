using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.DiagnosticLabs
{
    public  class DiagnosticLabModel
    {
         public int DiagnosticLabVendorID { get; set; }
        public string DiagnosticLabVendorEmail { get; set; }
        public string DiagnosticLabVendorPassword { get; set; }
        public string DiagnosticLabVendorUserName { get; set; }
        public string message { get; set; }

        public int returnId { get; set; }

        public bool status { get; set; }

    }
}

