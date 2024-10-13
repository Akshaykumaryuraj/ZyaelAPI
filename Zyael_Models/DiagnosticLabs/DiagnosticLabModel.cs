using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.DiagnosticLabs
{
    public  class DiagnosticLabModel
    {
         public int DLVID { get; set; }
         public int DLVPID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string message { get; set; }
        public string Gender { get; set; }
        public Int64 Mobile { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string DiagnosticLabProfileImageName { get; set; }
        public string DiagnosticLabProfileImagePath { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int returnId { get; set; }

        public bool status { get; set; }

    }
}

