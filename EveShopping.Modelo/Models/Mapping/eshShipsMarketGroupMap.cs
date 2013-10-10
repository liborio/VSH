using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshShipsMarketGroupMap : EntityTypeConfiguration<eshShipsMarketGroup>
    {
        public eshShipsMarketGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.marketGroupID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.marketGroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshShipsMarketGroups");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.marketGroupID).HasColumnName("marketGroupID");
            this.Property(t => t.mock).HasColumnName("mock");

            // Relationships
            this.HasRequired(t => t.invMarketGroup)
                .WithMany(t => t.eshShipsMarketGroups)
                .HasForeignKey(d => d.marketGroupID);
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshShipsMarketGroups)
                .HasForeignKey(d => d.typeID);

        }
    }
}
