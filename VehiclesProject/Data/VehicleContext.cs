using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using VehiclesProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VehiclesProject.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleContext")
        {
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}