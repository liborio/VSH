using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invPositionMap : EntityTypeConfiguration<invPosition>
    {
        public invPositionMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invPositions");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.yaw).HasColumnName("yaw");
            this.Property(t => t.pitch).HasColumnName("pitch");
            this.Property(t => t.roll).HasColumnName("roll");
        }
    }
}
