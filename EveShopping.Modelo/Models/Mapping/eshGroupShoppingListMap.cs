using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshGroupShoppingListMap : EntityTypeConfiguration<eshGroupShoppingList>
    {
        public eshGroupShoppingListMap()
        {
            // Primary Key
            this.HasKey(t => t.groupShoppingListID);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.description)
                .HasMaxLength(3990);

            this.Property(t => t.publicID)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("eshGroupShoppingList");
            this.Property(t => t.groupShoppingListID).HasColumnName("groupShoppingListID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.publicID).HasColumnName("publicID");
            this.Property(t => t.dateCreation).HasColumnName("dateCreation");
            this.Property(t => t.dateUpdate).HasColumnName("dateUpdate");
            this.Property(t => t.tradeHubID).HasColumnName("tradeHubID");

            // Relationships
            this.HasRequired(t => t.UserProfile)
                .WithMany(t => t.eshGroupShoppingLists)
                .HasForeignKey(d => d.userID);
            this.HasRequired(t => t.eshTradeHub)
                .WithMany(t => t.eshGroupShoppingLists)
                .HasForeignKey(d => d.tradeHubID);

        }
    }
}
