using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailApp.ViewModels.User
{
    public class UserRegisterViewModel : BaseViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be at least 2 symbols. Maximum - 20")]
        [Remote("CheckUsername","User",ErrorMessage="This username already token.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-z]+[-\._0-9a-z]*@[0-9a-z]+[-\._^0-9a-z]*[0-9a-z]+[\.]{1}[a-z]{2,6}$",ErrorMessage="Not valid email.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be at least 2 symbols. Maximum - 20")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be at least 5 symbols. Maximum - 20")]
        public string Password { get; set; }
    }
}