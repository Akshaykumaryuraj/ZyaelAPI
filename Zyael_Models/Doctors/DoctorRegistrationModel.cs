using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Doctors
{
    public class DoctorRegistrationModel
    {
        public int DoctorID { get; set; }
        public String EmailAddress { get; set; }
        public String Password { get; set; }
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Studies { get; set; }
        public String Experience { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public String ConsultationFees { get; set; }
        public String status { get; set; }
        public String City { get; set; }
        public String ProficientLanguage { get; set; }
        public String Specialization { get; set; }
        public String message { get; set; }
        public int AdminID { get; set; }
        public int MedicalID { get; set; }
        public int UserID { get; set; }
        public int returnId { get; set; }
        public string DoctorRegisterForHospital { get; set; }
        public string DoctorRegisterForClinic { get; set; }
        public decimal  Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
       
    }
}
