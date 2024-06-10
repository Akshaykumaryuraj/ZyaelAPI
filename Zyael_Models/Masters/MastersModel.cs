using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Masters
{
    public class MastersModel
    {
        public int AllergyID { get; set; }
        public string AllergyName { get; set; }
    }
    public class BloodGroupModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class CurrentMedicationModel
    {
        public int CMID { get; set; }
        public string MedicationName { get; set; }
    }
    public class PastMedicationModel
    {
        public int PMID { get; set; }
        public string PastMedicationName { get; set; }
    }
    public class ChronicMedicationModel
    {
        public int CMID { get; set; }
        public string ChronicMedicationName { get; set; }
    }
    public class InjuriesModel
    {
        public int InjuryID { get; set; }
        public string InjuryName { get; set; }
    }

    public class SurgeriesModel
    {
        public int SurgeryID { get; set; }
        public string SurgeryName { get; set; }
    }

    public class SmokingHabitsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class AlcoholHabitsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public enum GenderType
    {
        Male = 1,
        Female = 2
    }
}
