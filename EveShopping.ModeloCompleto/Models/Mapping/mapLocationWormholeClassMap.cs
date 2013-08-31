using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapLocationWormholeClassMap : EntityTypeConfiguration<mapLocationWormholeClass>
    {
        public mapLocationWormholeClassMap()
        {
            // Primary Key
            this.HasKey(t => t.locationID);

            // Properties
            this.Property(t => t.locationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapLocationWormholeClasses");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.wormholeClassID).HasColumnName("wormholeClassID");
        }
    }
}
