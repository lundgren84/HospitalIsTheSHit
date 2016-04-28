using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THIS_Hospital
{
    public class Room
    {
        //------------------------------------------------      
       
        public int RoomID { get; set; }

        [Display(Name = "Room nr")]
        public int RoomNr { get; set; }
        //------------------------------------------------  
        public bool Avalible { get; set; }

        //------------------------------------------------  
        public virtual Department Department { get; set; }

    }
}