using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace THIS_Hospital
{
    public class Drug
    {      
        public int DrugID { get; set; } //Prymary Key
        [Required]
        public string Description { get; set; }

        public int? DrugTypeRefID { get; set; }
        [ForeignKey(name: "DrugTypeRefID")]
        public DrugType DrugType { get; set; } //foreignkey

        public ICollection<Prescription> Prescriptions { get; set; }
        public Drug()
        {
            this.Prescriptions = new HashSet<Prescription>();
        }
       
    }
}