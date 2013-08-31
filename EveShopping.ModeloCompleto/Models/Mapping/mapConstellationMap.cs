using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapConstellationMap : EntityTypeConfiguration<mapConstellation>
    {
        public mapConstellationMap()
        {
            // Primary Key
            this.HasKey(t => t.constellationID);

            // Properties
            this.Property(t => t.constellationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.constellationName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("mapConstellations");
            this.Property(t => t.regionID).HasColumnName("regionID");
            this.Property(t => t.constellationID).HasColumnName("constellationID");
            this.Property(t => t.constellationName).HasColumnName("constellationName");
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
