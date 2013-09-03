using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshFittingMap : EntityTypeConfiguration<eshFitting>
    {
        public eshFittingMap()
        {
            // Primary Key
            this.HasKey(t => t.fittingID);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("eshFittings");
            this.Property(t => t.fittingID).HasColumnName("fittingID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.shipTypeID).HasColumnName("shipTypeID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.slotID).HasColumnName("slotID");
            this.Property(t => t.dateCreation).HasColumnName("dateCreation");

            // Relationships
            this.HasRequired(t => t.eshFittingSlot)
                .WithMany(t => t.eshFittings)
                .HasForeignKey(d => d.slotID);
            this.HasOptional(t => t.invType)
                .WithMany(t => t.eshFittings)
                .HasForeignKey(d => d.shipTypeID);

        }
    }
}
