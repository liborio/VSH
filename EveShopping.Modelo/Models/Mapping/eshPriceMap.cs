using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshPriceMap : EntityTypeConfiguration<eshPrice>
    {
        public eshPriceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.solarSystemID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.solarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("eshPrices");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.avg).HasColumnName("avg");
            this.Property(t => t.updateTime).HasColumnName("updateTime");

            // Relationships
            this.HasRequired(t => t.invType)
                .WithMany(t => t.eshPrices)
                .HasForeignKey(d => d.typeID);
            this.HasRequired(t => t.mapSolarSystem)
                .WithMany(t => t.eshPrices)
                .HasForeignKey(d => d.solarSystemID);

        }
    }
}
