using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshShoppingListFittingMap : EntityTypeConfiguration<eshShoppingListFitting>
    {
        public eshShoppingListFittingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.shoppingListID, t.fittingID });

            // Properties
            this.Property(t => t.shoppingListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fittingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshShoppingListFittings");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.fittingID).HasColumnName("fittingID");
            this.Property(t => t.units).HasColumnName("units");

            // Relationships
            this.HasRequired(t => t.eshFitting)
                .WithMany(t => t.eshShoppingListFittings)
                .HasForeignKey(d => d.fittingID);
            this.HasRequired(t => t.eshShoppingList)
                .WithMany(t => t.eshShoppingListFittings)
                .HasForeignKey(d => d.shoppingListID);

        }
    }
}
