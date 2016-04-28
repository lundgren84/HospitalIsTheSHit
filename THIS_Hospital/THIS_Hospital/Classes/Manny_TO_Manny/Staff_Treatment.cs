﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THIS_Hospital.Classes.Manny_TO_Manny
{
    public class Staff_Treatment
    {
        [Key, Column(Order = 0)]
        public int StaffID { get; set; }    
        public virtual Staff Staff { get; set; }


        [Key, Column(Order = 1)]
        public int TreatmentID { get; set; }      
        public virtual Treatment Treatment { get; set; }

 

      

       
    }
}