using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapSolarSystemMap : EntityTypeConfiguration<mapSolarSystem>
    {
        public mapSolarSystemMap()
        {
            // Primary Key
            this.HasKey(t => t.solarSystemID);

            // Properties
            this.Property(t => t.solarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.solarSystemName)
                .HasMaxLength(100);

            this.Property(t => t.securityClass)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("mapSolarSystems");
            this.Property(t => t.regionID).HasColumnName("regionID");
            this.Property(t => t.constellationID).HasColumnName("constellationID");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.solarSystemName).HasColumnName("solarSystemName");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.xMin).HasColumnName("xMin");
            this.Property(t => t.xMax).HasColumnName("xMax");
            this.Property(t => t.yMin).HasColumnName("yMin");
            this.Property(t => t.yMax).HasColumnName("yMax");
            this.Property(t => t.zMin).HasColumnName("zMin");
            this.Property(t => t.zMax).HasColumnName("zMax");
            this.Property(t => t.luminosity).HasColumnName("luminosity");
            this.Property(t => t.border).HasColumnName("border");
            this.Property(t => t.fringe).HasColumnName("fringe");
            this.Property(t => t.corridor).HasColumnName("corridor");
            this.Property(t => t.hub).HasColumnName("hub");
            this.Property(t => t.international).HasColumnName("international");
            this.Property(t => t.regional).HasColumnName("regional");
            this.Property(t => t.constellation).HasColumnName("constellation");
            this.Property(t => t.security).HasColumnName("security");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.radius).HasColumnName("radius");
            this.Property(t => t.sunTypeID).HasColumnName("sunTypeID");
            this.Property(t => t.securityClass).HasColumnName("securityClass");
        }
    }
}
