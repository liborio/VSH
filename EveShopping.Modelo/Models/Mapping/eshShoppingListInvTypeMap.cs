using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshShoppingListInvTypeMap : EntityTypeConfiguration<eshShoppingListInvType>
    {
        public eshShoppingListInvTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.shoppingListID, t.typeID });

            // Properties
            this.Property(t => t.shoppingListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshShoppingListInvType");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.units).HasColumnName("units");
            this.Property(t => t.volume).HasColumnName("volume");

            // Relationships
            this.HasRequired(t => t.eshShoppingList)
                .WithMany(t => t.eshShoppingListInvTypes)
                .HasForeignKey(d => d.shoppingListID);
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshShoppingListInvTypes)
                .HasForeignKey(d => d.typeID);

        }
    }
}
