using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class mapConstellationJumpMap : EntityTypeConfiguration<mapConstellationJump>
    {
        public mapConstellationJumpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.fromConstellationID, t.toConstellationID });

            // Properties
            this.Property(t => t.fromConstellationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.toConstellationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapConstellationJumps");
            this.Property(t => t.fromRegionID).HasColumnName("fromRegionID");
            this.Property(t => t.fromConstellationID).HasColumnName("fromConstellationID");
            this.Property(t => t.toConstellationID).HasColumnName("toConstellationID");
            this.Property(t => t.toRegionID).HasColumnName("toRegionID");
        }
    }
}
