using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.DiagnosticLabs
{
    public class DiagnosticLabProfileModel
    {
    }

    public class DiagnosticLabProfileImageModel
    {
        public int DLVID { get; set; }
        public int DLVPID { get; set; }
        public int DiagnosticLabProfileImageID { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public IFormFile DiagnosticLabProfileImage { get; set; }

        public string DiagnosticLabProfileImageName { get; set; }
        public string DiagnosticLabProfileImagePath { get; set; }
    }
}
