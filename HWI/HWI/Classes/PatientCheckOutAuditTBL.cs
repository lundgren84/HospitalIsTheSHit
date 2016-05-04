using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class PatientCheckOutAuditTBL
    {
        [Key]
        public int AuditID { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Doctor { get; set; }
        public string Cause { get; set; }
        public string CauseType { get; set; }
        public string PatientStatus { get; set; }
    }
}