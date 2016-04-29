using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HWI
{
    public class Staff : Person
    {
       
 
        
        [Display(Name = "Hire date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public int? ProffesionRefID { get; set; }
        [ForeignKey("ProffesionRefID")]
        public virtual Proffesion Proffesion { get; set; }

        //public virtual ICollection<Treatment> Treatments { get; set; }

        ////-----------Construktor-------

        //public Staff()
        //{
        //    this.Treatments = new HashSet<Treatment>();
        //}
    }
}