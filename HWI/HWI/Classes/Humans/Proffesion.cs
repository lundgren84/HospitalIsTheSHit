
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HWI
{
    public class Proffesion
    {
        //---------P-Key---------------
        public int ProffesionID { get; set; }

        //---------Properties--------------
        [Required]
        [Display(Name = "Proffesion")]
        public string Profession_Name { get; set; }



    }
}