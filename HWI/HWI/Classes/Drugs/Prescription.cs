using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Prescription
    {
        [Required]
        public int PrescriptionID { get; set; }// Primary key  
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int? PatientRefID { get; set; }
        [ForeignKey(name: "PatientRefID")]
        public virtual Patient Patient { get; set; }

        public int? StaffRefID { get; set; }
        [ForeignKey(name: "StaffRefID")]
        public virtual Staff Staff { get; set; }

        public int? DrugRefID { get; set; }
        [ForeignKey(name: "DrugRefID")]
        public virtual Drug Drug { get; set; }


    }
}