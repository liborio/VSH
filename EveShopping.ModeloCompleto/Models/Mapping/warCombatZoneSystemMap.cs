using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class warCombatZoneSystemMap : EntityTypeConfiguration<warCombatZoneSystem>
    {
        public warCombatZoneSystemMap()
        {
            // Primary Key
            this.HasKey(t => t.solarSystemID);

            // Properties
            this.Property(t => t.solarSystemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("warCombatZoneSystems");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.combatZoneID).HasColumnName("combatZoneID");
        }
    }
}
