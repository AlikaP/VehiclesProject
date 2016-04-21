using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VehiclesProject.DAL.Entities;
using VehiclesProject.DAL.Mapping;

namespace VehiclesProject.DAL
{
    public class VehicleContext : DbContext, IApplicationDbContext
    {
        public VehicleContext() : base("VehicleContext")
        {
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new VehicleMakeMap());
            modelBuilder.Configurations.Add(new VehicleModelMap());   
        }
    }

    public interface IApplicationDbContext : IDisposable
    {      
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}