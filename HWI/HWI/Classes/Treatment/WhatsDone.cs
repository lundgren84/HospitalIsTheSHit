﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class WhatsDone
    {
        //------------------------------------------------
        public int WhatsDoneID { get; set; }

        //------------------------------------------------
        [Display(Name ="Procedure")]
        [StringLength(30, ErrorMessage = "The description cant be longer than 30 characters!!")]
        public string Description { get; set; }
        public ICollection<Treatment> treatments { get; set; }
    }
}