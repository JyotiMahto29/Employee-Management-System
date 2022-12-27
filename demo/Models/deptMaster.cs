using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class deptMaster
    {
        [Key]
        public int deptId { get; set; }
        [Display(Name = "Dept Name :  ")]
        [Required(ErrorMessage = "This Field is required!")]
        public string deptName { get; set; }
    }
}