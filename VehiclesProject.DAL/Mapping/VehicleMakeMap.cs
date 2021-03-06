﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL.Entities;

namespace VehiclesProject.DAL.Mapping
{
    public class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
    {
        public VehicleMakeMap()
        {
            // Primary key.
            this.HasKey(t => t.Id);

            // Table & column Mappings.
            this.ToTable("VehicleMake");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Abrev).HasColumnName("Abrev");
        }
    }
}
