using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class warCombatZoneMap : EntityTypeConfiguration<warCombatZone>
    {
        public warCombatZoneMap()
        {
            // Primary Key
            this.HasKey(t => t.combatZoneID);

            // Properties
            this.Property(t => t.combatZoneID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.combatZoneName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("warCombatZones");
            this.Property(t => t.combatZoneID).HasColumnName("combatZoneID");
            this.Property(t => t.combatZoneName).HasColumnName("combatZoneName");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.centerSystemID).HasColumnName("centerSystemID");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
