using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshGroupShoppingListSnapshotMap : EntityTypeConfiguration<eshGroupShoppingListSnapshot>
    {
        public eshGroupShoppingListSnapshotMap()
        {
            // Primary Key
            this.HasKey(t => new { t.groupShoppingListID, t.snapshotID });

            // Properties
            this.Property(t => t.groupShoppingListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.snapshotID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nickName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("eshGroupShoppingListSnapshot");
            this.Property(t => t.groupShoppingListID).HasColumnName("groupShoppingListID");
            this.Property(t => t.snapshotID).HasColumnName("snapshotID");
            this.Property(t => t.nickName).HasColumnName("nickName");
            this.Property(t => t.creationDate).HasColumnName("creationDate");

            // Relationships
            this.HasRequired(t => t.eshGroupShoppingList)
                .WithMany(t => t.eshGroupShoppingListSnapshots)
                .HasForeignKey(d => d.groupShoppingListID);
            this.HasRequired(t => t.eshSnapshot)
                .WithMany(t => t.eshGroupShoppingListSnapshots)
                .HasForeignKey(d => d.snapshotID);

        }
    }
}
