using ApplicationCore.Validatiors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage ="Email cannot be empty")]
        [EmailAddress(ErrorMessage ="Email address shoudl be in right format")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name cannot be empty")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage="Password cannot be empty")]
        // minimum of 8 characters
        // 1 number, 1 uppercase, 1 lowercase
        // strong password
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage=
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        // minimum year and max year that a person can enter
        // not built in validation, use Custom Validator
        [YearValidation(1900)]
        public DateTime DaetOfBirth { get; set; }
    }
}
