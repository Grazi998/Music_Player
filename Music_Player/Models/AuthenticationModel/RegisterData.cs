using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models.AuthenticationModel
{
    public class LoginModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

    }
    public class RegisterData : LoginModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
