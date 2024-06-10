using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.InternalDoctor;

namespace Zyael_Models.Clinics
{
    public class ClinicVendorProfileModel
    {
        public int ClinicProfileID { get; set; }
        public int ClinicVendorID { get; set; }
        public string ClinicVendorUserName { get; set; }

        public string ClinicVendorEmail { get; set; }
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
        public string ClinicAddress_1 { get; set; }
        public string ClinicAddress_2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }


        //public string Address_1 { get; set; }
        //public string Address_2 { get; set; }
        //public IFormFile ClinicProfileImage { get; set; }

        //public string ClinicProfileImageName { get; set; }
        //public string ClinicProfileImagePath { get; set; }
    }

    public class ClinicDoctorModel
    {
        public int ClinicDoctorID { get; set; }
        public int ClinicVendorID { get; set; }
        public string ClinicVendorUserName { get; set; }
        public string GoogleMapLink { get; set; }
        public string ClinicAddress_1 { get; set; }
        public string ClinicAddress_2 { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
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
        public String ProficientLanguage { get; set; }
        public string DoctorBio { get; set; }
        public string DoctorBio_1 { get; set; }
        public string DoctorBio_2 { get; set; }
        public string DoctorProcedure { get; set; }
        public string DoctorProcedure_1 { get; set; }
        public string DoctorProcedure_2 { get; set; }
        public string DoctorIntroVideoLink { get; set; }
        public int TotalrowCount { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


    }

    public class ClinicDoctorSlotModel
    {
        public int SlotID { get; set; }
        public bool Available { get; set; }
        public string SlotsAvailable { get; set; }
        public string Time { get; set; }
        public List<Shits> Shits { get; set; }
        public int ClinicDoctorID { get; set; }
        public int ClinicVendorID { get; set; }
        public int count { get; set; }
        public DateTime Date { get; set; }

    }

    public class ClinicSlotDateModel
    {

        public int SlotID { get; set; }
        public bool Available { get; set; }
        public string Time { get; set; }
        public int ClinicDoctorID { get; set; }
        public int ClinicVendorID { get; set; }
        //public List<Shits> Shits { get; set; }

        public DateTime Date { get; set; }

    }


}
