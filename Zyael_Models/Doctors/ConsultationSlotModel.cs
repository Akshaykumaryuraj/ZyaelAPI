using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Doctors
{
    public  class ConsultationSlotModel
    {
        public int ConsultionSlotID { get; set; }
        public string ConsultationCategoryName { get; set; }
        public bool Available { get; set; }
        public string SlotsAvailable { get; set; }
        public string Time { get; set; }
        public List<slots> slots { get; set; }
        public int DoctorID { get; set; }
        public int HospitalVendorID { get; set; }
        public int ClinicVendorID { get; set; }
        public int count { get; set; }
        public DateTime Date { get; set; }

    }

    public class ConsultationSlotDateModel
    {
       
        public bool Available { get; set; }
        public string Time { get; set; }
        public int DoctorID { get; set; }
      
        public DateTime Date { get; set; }

    }
    public class slots
    {
        public string Time { get; set; }
        public bool Available { get; set; }
    }
}
