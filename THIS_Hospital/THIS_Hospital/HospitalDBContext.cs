using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;




namespace THIS_Hospital
{
    public class HospitalDBContext : DbContext
    {
        public DbSet<Staff> _Staff { get; set; }
        public DbSet<Patient> _Patient { get; set; }
        public DbSet<Proffesion> _Proffesion { get; set; }
        public DbSet<Treatment> _Treatment { get; set; }
        public DbSet<WhatsDone> _WhatsDone{ get; set; }
        public DbSet<TreatmentStatus> _Treatmentstatus { get; set; }
        public DbSet<Cause> _Cause { get; set; }
        public DbSet<CauseType> _CauseType { get; set; }



        public HospitalDBContext() : base("name =HospitalDBContextConectionString")
        {

        }

   

        public System.Data.Entity.DbSet<THIS_Hospital.Proffesion_CauseType> Proffesion_CauseType { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.Classes.Manny_TO_Manny.Staff_Treatment> Staff_Treatment { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.Drug> Drugs { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.Prescription> Prescriptions { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<THIS_Hospital.DrugType> DrugTypes { get; set; }
    }
}