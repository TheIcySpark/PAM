using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string GoogleUserID { get; set; }
        public string UserName { get; set; }
        public byte[] Photo { get; set; }
    }

}
