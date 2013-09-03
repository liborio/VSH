using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invItemMap : EntityTypeConfiguration<invItem>
    {
        public invItemMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invItems");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.ownerID).HasColumnName("ownerID");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.flagID).HasColumnName("flagID");
            this.Property(t => t.quantity).HasColumnName("quantity");
        }
    }
}
