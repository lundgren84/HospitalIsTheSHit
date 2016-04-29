using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THIS_Hospital
{

    // will be tha base class of the "drug" thingymaging
    public class DrugType
    {
        public DrugType()
        {
            this.Drugs = new HashSet<Drug>();
        }

        public int DrugTypeID { get; set; } //Prymary key
        [Display(Name = "Drug Type")]
        public string Desecription { get; set; }


        public ICollection<Drug> Drugs { get; set; }
 

    }
}