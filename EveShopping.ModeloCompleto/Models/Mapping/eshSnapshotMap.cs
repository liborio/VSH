using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshSnapshotMap : EntityTypeConfiguration<eshSnapshot>
    {
        public eshSnapshotMap()
        {
            // Primary Key
            this.HasKey(t => t.snapshotID);

            // Properties
            // Table & Column Mappings
            this.ToTable("eshSnapshot");
            this.Property(t => t.snapshotID).HasColumnName("snapshotID");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.creationDate).HasColumnName("creationDate");
            this.Property(t => t.totalVolume).HasColumnName("totalVolume");
            this.Property(t => t.totalPrice).HasColumnName("totalPrice");

            // Relationships
            this.HasOptional(t => t.eshShoppingList)
                .WithMany(t => t.eshSnapshots)
                .HasForeignKey(d => d.shoppingListID);

        }
    }
}
