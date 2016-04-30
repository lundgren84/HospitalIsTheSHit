using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Staff_Treatment
    {
        [Key,Column(Order =0)]
        public int TreatmentID { get; set; }
        public virtual Treatment _Treatment { get; set; }


        [Key, Column(Order = 1)]
        public int PersonID { get; set; }
        public virtual Staff _Staff { get; set; }



 
    }  
       
}