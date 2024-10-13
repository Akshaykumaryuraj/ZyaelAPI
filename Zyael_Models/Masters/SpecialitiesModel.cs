using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Masters
{
    public class SpecialitiesModel
    {
        public int SpecialityID { get; set; }
        public string SpecialityName { get; set; }
        public string SpecialityCode { get; set; }
        public string Symptoms { get; set; }
        public IFormFile SpecialityProfileImage { get; set; }

        public string SpecialityProfileImageName { get; set; }
        public string SpecialityProfileImagePath { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}
