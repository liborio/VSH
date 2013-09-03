using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invNameMap : EntityTypeConfiguration<invName>
    {
        public invNameMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.itemName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("invNames");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.itemName).HasColumnName("itemName");
        }
    }
}
