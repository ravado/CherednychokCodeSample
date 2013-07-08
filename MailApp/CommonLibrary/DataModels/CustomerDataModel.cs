using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.DataModels
{
    public class CustomerDataModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-z]+[-\._0-9a-z]*@[0-9a-z]+[-\._^0-9a-z]*[0-9a-z]+[\.]{1}[a-z]{2,6}$", ErrorMessage = "Not valid email.")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be at least 3 symbols. Maximum - 20")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(20,MinimumLength=3, ErrorMessage="Must be at least 3 symbols. Maximum - 20")]
        public string CustomerName { get; set; }

        [Required]        
        public DateTime RegistrationDate { get; set; }
    }
}
