using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Treatment
    {

   

        //------------------------------------------------  
        public int TreatmentID { get; set; }

        //------------------------------------------------  
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //------------------------------------------------     
        public bool StillAlive { get; set; }

        //------------------------------------------------  
        public int? PatientRefID { get; set; }
        [ForeignKey(name: "PatientRefID")]
        public virtual Patient Patient { get; set;}

        //------------------------------------------------
        public int? WhatsDoneRefID { get; set; }
        [ForeignKey(name: "WhatsDoneRefID")]
        public virtual WhatsDone WhatsDone { get; set; }

        //------------------------------------------------
        public int? TreatmentStatusRefID { get; set; }
        [ForeignKey(name: "TreatmentStatusRefID")]
        public virtual TreatmentStatus TreatmentStatus { get; set; }

        //-----------------------------------------------

        //public virtual ICollection<Staff> staffs { get; set; }

        //public Treatment()
        //{
        //    this.staffs = new HashSet<Staff>();
        //}
      

    }
}