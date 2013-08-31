using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapUniverseMap : EntityTypeConfiguration<mapUniverse>
    {
        public mapUniverseMap()
        {
            // Primary Key
            this.HasKey(t => t.universeID);

            // Properties
            this.Property(t => t.universeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.universeName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("mapUniverse");
            this.Property(t => t.universeID).HasColumnName("universeID");
            this.Property(t => t.universeName).HasColumnName("universeName");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.xMin).HasColumnName("xMin");
            this.Property(t => t.xMax).HasColumnName("xMax");
            this.Property(t => t.yMin).HasColumnName("yMin");
            this.Property(t => t.yMax).HasColumnName("yMax");
            this.Property(t => t.zMin).HasColumnName("zMin");
            this.Property(t => t.zMax).HasColumnName("zMax");
            this.Property(t => t.radius).HasColumnName("radius");
        }
    }
}
