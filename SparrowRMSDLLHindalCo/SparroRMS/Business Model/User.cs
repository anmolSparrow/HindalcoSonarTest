using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
   public class User
    {

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public DateTime? DOB { get; set; }

        public string contact { get; set; }

        public string alternateContact { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public  string Appid { get; set; }
        public string userTypeId { get; set; }
        public string sex { get; set; }
        public bool isActive { get; set; }

      //  public string UPwd { get; set; }
    }
} 
