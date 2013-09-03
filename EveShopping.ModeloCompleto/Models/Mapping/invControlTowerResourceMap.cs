using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invControlTowerResourceMap : EntityTypeConfiguration<invControlTowerResource>
    {
        public invControlTowerResourceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.controlTowerTypeID, t.resourceTypeID });

            // Properties
            this.Property(t => t.controlTowerTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.resourceTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invControlTowerResources");
            this.Property(t => t.controlTowerTypeID).HasColumnName("controlTowerTypeID");
            this.Property(t => t.resourceTypeID).HasColumnName("resourceTypeID");
            this.Property(t => t.purpose).HasColumnName("purpose");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.minSecurityLevel).HasColumnName("minSecurityLevel");
            this.Property(t => t.factionID).HasColumnName("factionID");
        }
    }
}
