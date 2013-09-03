using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invControlTowerResourcePurposMap : EntityTypeConfiguration<invControlTowerResourcePurpos>
    {
        public invControlTowerResourcePurposMap()
        {
            // Primary Key
            this.HasKey(t => t.purpose);

            // Properties
            this.Property(t => t.purposeText)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("invControlTowerResourcePurposes");
            this.Property(t => t.purpose).HasColumnName("purpose");
            this.Property(t => t.purposeText).HasColumnName("purposeText");
        }
    }
}
