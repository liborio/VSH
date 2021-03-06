using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
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

            this.Property(t => t.readOnlypublicID)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("eshShoppingLists");
            this.Property(t => t.shoppingListID).HasColumnName("shoppingListID");
            this.Property(t => t.publicID).HasColumnName("publicID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.dateCreation).HasColumnName("dateCreation");
            this.Property(t => t.readOnlypublicID).HasColumnName("readOnlypublicID");
            this.Property(t => t.dateUpdate).HasColumnName("dateUpdate");
            this.Property(t => t.tradeHubID).HasColumnName("tradeHubID");
            this.Property(t => t.dateAccess).HasColumnName("dateAccess");
            this.Property(t => t.allowEditForAll).HasColumnName("allowEditForAll");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.urlID).HasColumnName("urlID");

            // Relationships
            this.HasRequired(t => t.eshTradeHub)
                .WithMany(t => t.eshShoppingLists)
                .HasForeignKey(d => d.tradeHubID);
            this.HasOptional(t => t.UserProfile)
                .WithMany(t => t.eshShoppingLists)
                .HasForeignKey(d => d.userID);

        }
    }
}
