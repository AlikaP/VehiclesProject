﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL.Entities;

namespace VehiclesProject.DAL.Mapping
{
    public class VehicleModelMap : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("VehicleModel");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MakeId).HasColumnName("MakeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Abrev).HasColumnName("Abrev");

            // Relationships
            this.HasRequired(s => s.Make)
                    .WithMany(s => s.VehicleModels)
                    .HasForeignKey(s => s.MakeId);

        }
    }
}
