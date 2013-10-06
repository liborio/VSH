using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshSnapshotInvTypeMap : EntityTypeConfiguration<eshSnapshotInvType>
    {
        public eshSnapshotInvTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.snapshotID, t.typeID });

            // Properties
            this.Property(t => t.snapshotID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshSnapshotInvType");
            this.Property(t => t.snapshotID).HasColumnName("snapshotID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.units).HasColumnName("units");
            this.Property(t => t.unitPrice).HasColumnName("unitPrice");
            this.Property(t => t.volume).HasColumnName("volume");

            // Relationships
            this.HasRequired(t => t.eshSnapshot)
                .WithMany(t => t.eshSnapshotInvTypes)
                .HasForeignKey(d => d.snapshotID);
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshSnapshotInvTypes)
                .HasForeignKey(d => d.typeID);

        }
    }
}
