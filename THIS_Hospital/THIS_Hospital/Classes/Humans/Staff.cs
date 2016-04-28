using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace THIS_Hospital
{
    public class Staff
    {
        // ---------P-Key------------
        public int StaffID { get; set; }

        // ---------Properties--------
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = " You cant have longer name then 50 chars!!")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public string Adress { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNR { get; set; }
        [Display(Name = "Social Security Number")]
        [StringLength(10, ErrorMessage = "Only 10 numbers")]
        public string SSN { get; set; }
        [Display(Name = "Hire date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Display(Name = "Staff Name")]
        public string Name
        { get { return LName + "," + FName; } }

        // ----------F-Keys------------
        public int? ProffesionRefID { get; set; }
        [ForeignKey(name: "ProffesionRefID")]
        public virtual Proffesion Proffesion { get; set; }

        public int? DepartmentRefID { get; set; }
        [ForeignKey(name: "DepartmentRefID")]
        public virtual Department Department { get; set; }

        public ICollection<Treatment> Treatments { get; set; }

        //-----------Construktor-------
        public Staff()
        {
            this.Treatments = new HashSet<Treatment>();
        }
    }
}