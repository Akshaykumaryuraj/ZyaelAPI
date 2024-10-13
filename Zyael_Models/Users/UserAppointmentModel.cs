using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Doctors;

namespace Zyael_Models.Users
{
    public class UserAppointmentModel
    {
        public int UserAppointmentID { get; set; }
        public int UserRandomID { get; set; }
        public string ConsultationCategoryName { get; set; }
        public int UserPID { get; set; }
        public int UserID { get; set; }
        public string UserSelectedSlot { get; set; }

        public string FirstName { get; set; }

        public Int64 ContactNumber { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }
        public string BloodGroup { get; set; }

        public string SlotsAvailable { get; set; }
        public string Time { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }
        public bool AppointmentUpdate { get; set; }


    }

    public class  UserAppointmentScheduleModel
        {
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }
        public string UserSelectedSlot { get; set;}
        public int UserRandomID { get; set;}
        public int ConsultationFees { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Experience { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public String City { get; set; }
        public String ProficientLanguage { get; set; }
        public String Specialization { get; set; }
        public string PaymentID { get; set; }
        public string PaymentOrderID { get; set; }
        public string Status { get; set; }
        public bool AppointmentUpdate { get; set; }

    }

    public class UserHospitalAppointmentModel
    {
        public int UserID { get; set; }
        public int IDoctorID { get; set; }
        public int HospitalProfileID { get; set; }
        public int HospitalVendorID { get; set; }
        public DateTime Date { get; set; }
        public string UserSelectedSlot { get; set; }
        public int UserRandomID { get; set; }
        public int ConsultationFees { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Experience { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public String City { get; set; }
        public String ProficientLanguage { get; set; }
        public String Specialization { get; set; }
        public string PaymentID { get; set; }
        public string PaymentOrderID { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }

        public bool AppointmentUpdate { get; set; }



    }


    public class UserClinicAppointmentModel
    {
        public int UserID { get; set; }
        public int ClinicDoctorID { get; set; }
        public int ClinicVendorID { get; set; }
        public DateTime Date { get; set; }
        public string UserSelectedSlot { get; set; }
        public string ConsultationType { get; set; }
        public int UserRandomID { get; set; }
        public int ConsultationFees { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Experience { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public String City { get; set; }
        public String ProficientLanguage { get; set; }
        public String Specialization { get; set; }
        public string PaymentID { get; set; }
        public string PaymentOrderID { get; set; }
        public string Status { get; set; }
        public bool AppointmentUpdate { get; set; }


    }

    public class PaymentModel
    {
        public string PaymentID { get; set; }
        public string PaymentOrderID { get; set; }
        public int ConsultationFees { get; set; }
        public string transactionId { get; set; }
        public string merchantId { get; set; }
        public string result { get; set; }

    }

    public class UserCancelAppointmentModel
    {
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int UAID { get; set; }
       
        public string Comment { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }


    }

    public class slots
    {
        public string Time { get; set; }
        public bool Available { get; set; }
    }
}
