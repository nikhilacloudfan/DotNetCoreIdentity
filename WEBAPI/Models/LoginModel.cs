using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ResetPassword : LoginModel
    {
        public string ConfirmPassword { get; set; }
    }
}
