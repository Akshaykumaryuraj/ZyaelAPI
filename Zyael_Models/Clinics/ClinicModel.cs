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
        public string ClinicVendorUserName { get; set; }
        public string ClinicVendorName { get; set; }
        public string ClinicVendorEmail { get; set; }
        public string ClinicVendorPassword { get; set; }
        public string ClinicAddress_1 { get; set; }
        public string ClinicAddress_2 { get; set; }
        public string GoogleMapLink { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string message { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //public string Address_1 { get; set; }
        //public string Address_2 { get; set; }

        public int returnId { get; set; }

        public bool status { get; set; }

        }
    }

