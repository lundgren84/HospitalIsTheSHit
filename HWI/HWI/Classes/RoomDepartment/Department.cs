using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWI
{
    public class Department
    {
        public Department()
        {
            this.staffs = new HashSet<Staff>();
        }
        //------------------------------------------------  
        public int DepartmentID { get; set; }

        //------------------------------------------------  

        [StringLength(20)]
        public string DepartmentName { get; set; }

        public ICollection<Staff> staffs { get; set; }

    }
}