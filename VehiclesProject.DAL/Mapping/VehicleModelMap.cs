using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL.Entities;
using PagedList;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesProject.DAL.Mapping
{
    public class VehicleModelMap : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMap()
        {
            // Primary key.
            this.HasKey(t => t.Id);

            // Table & column Mappings.
            this.ToTable("VehicleModel");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.MakeId).HasColumnName("MakeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Abrev).HasColumnName("Abrev");

            // Relationships.
            this.HasRequired(s => s.Make)
                    .WithMany(s => s.VehicleModels)
                    .HasForeignKey(s => s.MakeId);
        }
    }
}
