using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [MinLength(5)]
        [Required]
        public string Password { get; set; }
    }

    public class ResetPassword : LoginModel
    {
        [Required]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}
