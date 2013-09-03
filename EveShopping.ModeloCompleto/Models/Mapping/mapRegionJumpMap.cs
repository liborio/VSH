using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class mapRegionJumpMap : EntityTypeConfiguration<mapRegionJump>
    {
        public mapRegionJumpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.fromRegionID, t.toRegionID });

            // Properties
            this.Property(t => t.fromRegionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.toRegionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapRegionJumps");
            this.Property(t => t.fromRegionID).HasColumnName("fromRegionID");
            this.Property(t => t.toRegionID).HasColumnName("toRegionID");
        }
    }
}
