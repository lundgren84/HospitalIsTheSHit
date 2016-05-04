using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HWI
{
    public class Patient : Person
    {
     

        //Time checked in to hospital
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInHospital { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CheckOut { get; set; }

        //-----------F-Keys------------

        public int? RoomRefID { get; set; }
        [ForeignKey(name: "RoomRefID")]
        public virtual Room Room { get; set; }

        public int? _StaffRefID { get; set; }
        [ForeignKey(name: "_StaffRefID")]
        public virtual Staff _Staff { get; set; }
        public int? _CauseRefID { get; set; }
        [ForeignKey(name: "_CauseRefID")]
        public virtual Cause _Cause { get; set; }
        //Full name
        [Display(Name = "Patient Name")]
        public string PatientName
        { get { return FName + " " + LName; } }
    }
}