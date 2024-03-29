using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Users
{
    public class UserProfileModel
    {
        public int UserPID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 ContactNumber { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus  { get; set; }
        public string Height  { get; set; }
        public string Weight  { get; set; }
        public Int64 EmergencyContact  { get; set; }
        public string Location  { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string PastMedications { get; set; }
        public string ChronicMedications { get; set; }
        public string Injuries { get; set; }
        public string Surgeries { get; set; }
        public string Smoking { get; set; }
        public string Alcohol { get; set; }
        public string FoodPreference { get; set; }
        public string Occupation { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
    }
}
