using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class chrFactionMap : EntityTypeConfiguration<chrFaction>
    {
        public chrFactionMap()
        {
            // Primary Key
            this.HasKey(t => t.factionID);

            // Properties
            this.Property(t => t.factionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.factionName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("chrFactions");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.factionName).HasColumnName("factionName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.raceIDs).HasColumnName("raceIDs");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.sizeFactor).HasColumnName("sizeFactor");
            this.Property(t => t.stationCount).HasColumnName("stationCount");
            this.Property(t => t.stationSystemCount).HasColumnName("stationSystemCount");
            this.Property(t => t.militiaCorporationID).HasColumnName("militiaCorporationID");
            this.Property(t => t.iconID).HasColumnName("iconID");
        }
    }
}
