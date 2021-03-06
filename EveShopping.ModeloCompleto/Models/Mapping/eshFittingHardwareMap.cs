using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshFittingHardwareMap : EntityTypeConfiguration<eshFittingHardware>
    {
        public eshFittingHardwareMap()
        {
            // Primary Key
            this.HasKey(t => t.fittingHardwareID);

            // Properties
            // Table & Column Mappings
            this.ToTable("eshFittingHardwares");
            this.Property(t => t.fittingHardwareID).HasColumnName("fittingHardwareID");
            this.Property(t => t.fittingID).HasColumnName("fittingID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.slotID).HasColumnName("slotID");
            this.Property(t => t.positionInSlot).HasColumnName("positionInSlot");
            this.Property(t => t.units).HasColumnName("units");
            this.Property(t => t.volume).HasColumnName("volume");

            // Relationships
            this.HasRequired(t => t.eshFitting)
                .WithMany(t => t.eshFittingHardwares)
                .HasForeignKey(d => d.fittingID);
            this.HasRequired(t => t.eshFittingSlot)
                .WithMany(t => t.eshFittingHardwares)
                .HasForeignKey(d => d.slotID);
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshFittingHardwares)
                .HasForeignKey(d => d.typeID);

        }
    }
}
