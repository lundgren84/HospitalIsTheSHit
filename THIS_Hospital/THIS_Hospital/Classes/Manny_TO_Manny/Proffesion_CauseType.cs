using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THIS_Hospital
{
    public class Proffesion_CauseType
    {
        [Key, Column(Order = 0)]
        public int ProffesionID { get; set; }
        [Key, Column(Order = 1)]
        public int CauseTypeID { get; set; }

        public int? ProffesionRefID { get; set; }
        [ForeignKey(name: "ProffesionRefID")]
        public virtual Proffesion Proffesion { get; set; }

        public int? CauseTypeRefID { get; set; }
        [ForeignKey(name: "CauseTypeRefID")]
        public virtual CauseType CauseType { get; set; }
    }
}