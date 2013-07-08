using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MailApp.ViewModels.User
{
    public class UserLoginViewModel : BaseViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be at least 2 symbols. Maximum - 20")]
        public string Username { get; set; }

        [Required]
        [StringLength(20,MinimumLength=5, ErrorMessage="Must be at least 5 symbols. Maximum - 20")]
        public string Password { get; set; }
    }
}