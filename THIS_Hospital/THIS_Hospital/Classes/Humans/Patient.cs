using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace THIS_Hospital
{
    public class Patient
    {
        // -----------P-Key------------
        public int PatientID { get; set; }

        //--------- Properties---------
        // First name
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        //Last name
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        //Adress
        [Required]
        public string Adress { get; set; }
        //Phone nr
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNR { get; set; }
        //Social Security Number
        [Required]
        [Display(Name = "Social Security Number")]
        [StringLength(10,ErrorMessage ="Only 10 numbers")]
        public string SSN { get; set; }
        //Time checked in to hospital
        [Required]
        [DataType(DataType.Date)]
        public DateTime CeckInHospital { get; set; }
        //Full name
        [Required]
        [Display(Name = "Full Name")]
        public string Name
        { get { return FName + " " + LName; }  }

        //-----------F-Keys------------
        public int? StaffRefID { get; set; }
        [ForeignKey(name: "StaffRefID")]
        public virtual Staff Staff { get; set; }

        public int? RoomRefID { get; set; }
        [ForeignKey(name: "RoomRefID")]
        public virtual Room Room { get; set; }

        // Många till många
        public ICollection<Cause> Causes { get; set; }


        // --------Construktor-----------
        public Patient()
        {
           this.Causes = new HashSet<Cause>();
        }





    }
}