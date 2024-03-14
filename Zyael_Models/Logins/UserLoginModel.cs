using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Logins
{
    public  class UserLoginModel
    {
      public int UserID { get; set; }

        public int returnId { get; set; }

        public string message { get; set; }
        public string Email { get; set; }
        public Int64 Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserType { get; set; }
        public string ResetPassword { get; set; }

    }
}
