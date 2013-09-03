using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapSolarSystemJumpMap : EntityTypeConfiguration<mapSolarSystemJump>
    {
        public mapSolarSystemJumpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.fromSolarSystemID, t.toSolarSystemID });

            // Properties
            this.Property(t => t.fromSolarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.toSolarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapSolarSystemJumps");
            this.Property(t => t.fromRegionID).HasColumnName("fromRegionID");
            this.Property(t => t.fromConstellationID).HasColumnName("fromConstellationID");
            this.Property(t => t.fromSolarSystemID).HasColumnName("fromSolarSystemID");
            this.Property(t => t.toSolarSystemID).HasColumnName("toSolarSystemID");
            this.Property(t => t.toConstellationID).HasColumnName("toConstellationID");
            this.Property(t => t.toRegionID).HasColumnName("toRegionID");
        }
    }
}
