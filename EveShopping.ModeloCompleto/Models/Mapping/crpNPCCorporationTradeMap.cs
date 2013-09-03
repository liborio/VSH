using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crpNPCCorporationTradeMap : EntityTypeConfiguration<crpNPCCorporationTrade>
    {
        public crpNPCCorporationTradeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.corporationID, t.typeID });

            // Properties
            this.Property(t => t.corporationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("crpNPCCorporationTrades");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.typeID).HasColumnName("typeID");
        }
    }
}
