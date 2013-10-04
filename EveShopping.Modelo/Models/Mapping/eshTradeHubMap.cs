using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshTradeHubMap : EntityTypeConfiguration<eshTradeHub>
    {
        public eshTradeHubMap()
        {
            // Primary Key
            this.HasKey(t => t.solarSystemID);

            // Properties
            this.Property(t => t.solarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshTradeHubs");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");

            // Relationships
            this.HasRequired(t => t.mapSolarSystem)
                .WithOptional(t => t.eshTradeHub);

        }
    }
}
