using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Proffesion_CauseType
    {
        [Key, Column(Order = 0)]
        public int ProffesionID { get; set; }
      

        [Key, Column(Order = 1)]
        public int CauseTypeID { get; set; }


        public virtual CauseType CauseType { get; set; }
        public virtual Proffesion Proffesion { get; set; }



    }
}