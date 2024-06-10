using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Admins
{
    public class AdminModel
    {
        public int AdminID { get; set; }
        public string Zyael { get; set; }
    }

    public class Zyael_PromiseModel
    {
        public int ZyaelPID { get; set; }
        public string Title { get; set; }
        public string CheckList_1 { get; set; }
        public string CheckList_2 { get; set; }
        public string CheckList_3 { get; set; }
        public string CheckList_4 { get; set; }
        public string desc_1 { get; set; }
        public string desc_2 { get; set; }
    }
}
