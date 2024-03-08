using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Logins
{
    public class LoginModel
    {


        public int returnId { get; set; }


        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string message { get; set; }

    }
}
