using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public abstract class Person
    {


        //-------P-Key------
      [Key]
        public int PersonID { get; set; }


        //First name
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        //Last name
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
   
        //Phone nr
        [Display(Name = "Phone Number")]
        public string PhoneNR { get; set; }

        //Social Security Number
        [Display(Name = "Social Security Number")]
        [StringLength(10)]
        public string SSN { get; set; }

        //Full name
        [Display(Name = "Full Name")]
        public string Name
        { get { return FName + " " + LName; } }
    }
}