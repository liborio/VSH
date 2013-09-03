using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapDenormalizeMap : EntityTypeConfiguration<mapDenormalize>
    {
        public mapDenormalizeMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.itemName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("mapDenormalize");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.groupID).HasColumnName("groupID");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.constellationID).HasColumnName("constellationID");
            this.Property(t => t.regionID).HasColumnName("regionID");
            this.Property(t => t.orbitID).HasColumnName("orbitID");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.radius).HasColumnName("radius");
            this.Property(t => t.itemName).HasColumnName("itemName");
            this.Property(t => t.security).HasColumnName("security");
            this.Property(t => t.celestialIndex).HasColumnName("celestialIndex");
            this.Property(t => t.orbitIndex).HasColumnName("orbitIndex");
        }
    }
}
