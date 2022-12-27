
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;


namespace demo.Models
{
    public class userMaster
    {
        [Key]
        public int userId { get; set; }
        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter User fName")]
        
        public string userName { get; set; }

        [Display(Name = "Email")]
        //[EmailAddress(ErrorMessage = "Please Enter Valid Email..")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[Remote("doesUserNameExist", "Registration", ErrorMessage = "User name already exists. Please enter a different user name.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "UserName length must between 5 to 20..")]

        public string userEmail { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length must between 8 to 20..")]
        public string userPassword { get; set; }

        [Display(Name = "Confirm password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length must between 8 to 20..")]
        [Compare("userPassword")]
        public string ConfirmPassword { get; set; }
    }
}