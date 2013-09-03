using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eveUnitMap : EntityTypeConfiguration<eveUnit>
    {
        public eveUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.unitID);

            // Properties
            this.Property(t => t.unitName)
                .HasMaxLength(100);

            this.Property(t => t.displayName)
                .HasMaxLength(50);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("eveUnits");
            this.Property(t => t.unitID).HasColumnName("unitID");
            this.Property(t => t.unitName).HasColumnName("unitName");
            this.Property(t => t.displayName).HasColumnName("displayName");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
