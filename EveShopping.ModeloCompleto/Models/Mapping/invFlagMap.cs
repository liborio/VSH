using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invFlagMap : EntityTypeConfiguration<invFlag>
    {
        public invFlagMap()
        {
            // Primary Key
            this.HasKey(t => t.flagID);

            // Properties
            this.Property(t => t.flagID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.flagName)
                .HasMaxLength(200);

            this.Property(t => t.flagText)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("invFlags");
            this.Property(t => t.flagID).HasColumnName("flagID");
            this.Property(t => t.flagName).HasColumnName("flagName");
            this.Property(t => t.flagText).HasColumnName("flagText");
            this.Property(t => t.orderID).HasColumnName("orderID");
        }
    }
}
