using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Masters
{
    public class SymptomsModel
    {
        public int SymptomsID { get; set; }
        public string SymptomTitle { get; set; }
        public List<symptomslist> symptomslist { get; set; }
        public bool Priority { get; set; }

    }

    public class symptomslist
    {
        public string SymptomList { get; set; }
        public string SymptomTitle { get; set; }

        public bool Priority { get; set; }

    }
}
