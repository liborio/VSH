using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapRegionMap : EntityTypeConfiguration<mapRegion>
    {
        public mapRegionMap()
        {
            // Primary Key
            this.HasKey(t => t.regionID);

            // Properties
            this.Property(t => t.regionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.regionName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("mapRegions");
            this.Property(t => t.regionID).HasColumnName("regionID");
            this.Property(t => t.regionName).HasColumnName("regionName");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.xMin).HasColumnName("xMin");
            this.Property(t => t.xMax).HasColumnName("xMax");
            this.Property(t => t.yMin).HasColumnName("yMin");
            this.Property(t => t.yMax).HasColumnName("yMax");
            this.Property(t => t.zMin).HasColumnName("zMin");
            this.Property(t => t.zMax).HasColumnName("zMax");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.radius).HasColumnName("radius");
        }
    }
}
