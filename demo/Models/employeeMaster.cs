using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
    public class employeeMaster
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Name : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter EmployeeName")]
        public string EmployeeName { get; set; }
        [DisplayName("Position : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Position")]
        public string Position { get; set; }
        [DisplayName("Salary : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Salary")]
        public Decimal Salary { get; set; }
        [DisplayName("Contact : ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Contact")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Contact { get; set; }
        [DisplayName(" Address: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [DisplayName(" EmailId: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Emailid")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; }
        [DisplayName(" Department Id: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter departmentId")]
        public int deptId { get; set; }
        [NotMapped]
        public SelectList ddldepartment { get; set; }
    }
}