using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.InternalDoctor
{
    public class InternalDoctorModel
    {
        public int IDoctorID { get; set; }
        public int HospitalVendorID { get; set; }
        public String EmailAddress { get; set; }
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Studies { get; set; }
        public String Experience { get; set; }
        public String Gender { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public int ConsultationFees { get; set; }
        public String Specialization { get; set; }
        public bool status { get; set; }
        public String City { get; set; }
        public String ProficientLanguage { get; set; }
        public string DoctorBio { get; set; }
        public string DoctorBio_1 { get; set; }
        public string DoctorBio_2 { get; set; }
        public string DoctorProcedure { get; set; }
        public string DoctorProcedure_1 { get; set; }
        public string DoctorProcedure_2 { get; set; }
        public string DoctorIntroVideoLink { get; set; }
        public string HospitalVendorUserName { get; set; }
        public int TotalrowCount { get; set; }
        public string IDoctorProfileImageName { get; set; }
        public string IDoctorProfileImagePath { get; set; }

    }

    public class Shits
    {
        public string Time { get; set; }
        public bool Available { get; set; }
    }

    public class ShiftSlotDateModel
    {

        public bool Available { get; set; }
        public string Time { get; set; }
        public int IDoctorID { get; set; }
        public int HospitalVendorID { get; set; }
        public List<Shits> Shits { get; set; }

        public DateTime Date { get; set; }

    }



    public class ShiftSlotModel
    {
        public int ShiftSlotID { get; set; }
        public bool Available { get; set; }
        public string SlotsAvailable { get; set; }
        public string Time { get; set; }
        public List<Shits> Shits { get; set; }
        public int IDoctorID { get; set; }
        public int HospitalVendorID { get; set; }
        public int count { get; set; }
        public DateTime Date { get; set; }

    }



    public class InternalDoctorProfileImageModel
    {
        public int IDoctorID { get; set; }
        public int IDoctorProfileImageID { get; set; }
        public int HospitalVendorID { get; set; }
        public IFormFile IDoctorProfileImage { get; set; }

        public string IDoctorProfileImageName { get; set; }
        public string IDoctorProfileImagePath { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
    }

}
