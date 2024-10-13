using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Hospitals
{
    public class HospitalVendorProfileModel
    {
        public int HospitalProfileID { get; set; }
        public int HospitalVendorID { get; set; }
        public string HospitalVendorUserName { get; set; }

        public string HospitalVendorEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Specialization { get; set; }
        public int Rating { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public Int64 EmergencyContact { get; set; }
        public Int64 ContactNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public bool status { get; set; }
        //public IFormFile HospitalProfileImage { get; set; }

        public string HospitalProfileImageName { get; set; }
        public string HospitalProfileImagePath { get; set; }
    }

    public class HospitalVendorProfileImageModel
    {
        public int HospitalProfileID { get; set; }
        public int HospitalProfileImageID { get; set; }
        public int HospitalVendorID { get; set; }
        public IFormFile HospitalProfileImage { get; set; }

        public string HospitalProfileImageName { get; set; }
        public string HospitalProfileImagePath { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
    }
}
