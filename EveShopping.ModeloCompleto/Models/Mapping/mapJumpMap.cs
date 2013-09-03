using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapJumpMap : EntityTypeConfiguration<mapJump>
    {
        public mapJumpMap()
        {
            // Primary Key
            this.HasKey(t => t.stargateID);

            // Properties
            this.Property(t => t.stargateID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapJumps");
            this.Property(t => t.stargateID).HasColumnName("stargateID");
            this.Property(t => t.celestialID).HasColumnName("celestialID");
        }
    }
}
