using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class eshShoppingListMap : EntityTypeConfiguration<eshShoppingList>
    {
        public eshShoppingListMap()
        {
            // Primary Key
            this.HasKey(t => t.shoppingListID);

            // Properties
            this.Property(t => t.publicID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.name)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3990);

            // Table & Column Mappings
            this.ToTable("eshShoppingLists");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.publicID).HasColumnName("publicID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
