using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Room
    {
        //------------------------------------------------  
       
        public int RoomID { get; set; }

        //------------------------------------------------       
        public int RoomNr { get; set; }

        //------------------------------------------------  
        public bool Avalible { get; set; }
        

        //------------------------------------------------  

        public virtual Department department { get; set; }
       
        
        


    }
}