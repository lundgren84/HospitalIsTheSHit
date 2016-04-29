using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace HWI
{
    public class HWIDBContext : DbContext
    {
        public HWIDBContext() : base("name =HWIDBContextConectionString")
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Proffesion> professions { get; set; }
        public DbSet<Staff_Treatment> staffTreatment { get; set; }
        public DbSet<Treatment> Treatments { get; set; }   
        public System.Data.Entity.DbSet<HWI.WhatsDone> WhatsDones { get; set; }
        public System.Data.Entity.DbSet<HWI.TreatmentStatus> TreatmentStatus { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }  
        public System.Data.Entity.DbSet<HWI.CauseType> CauseTypes { get; set; }



        
    }
}