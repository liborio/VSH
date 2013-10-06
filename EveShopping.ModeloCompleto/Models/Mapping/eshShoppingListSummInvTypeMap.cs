using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshShoppingListSummInvTypeMap : EntityTypeConfiguration<eshShoppingListSummInvType>
    {
        public eshShoppingListSummInvTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.shoppingListID, t.typeID });

            // Properties
            this.Property(t => t.shoppingListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshShoppingListSummInvTypes");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.delta).HasColumnName("delta");

            // Relationships
            this.HasRequired(t => t.eshShoppingList)
                .WithMany(t => t.eshShoppingListSummInvTypes)
                .HasForeignKey(d => d.shoppingListID);
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshShoppingListSummInvTypes)
                .HasForeignKey(d => d.typeID);

        }
    }
}
